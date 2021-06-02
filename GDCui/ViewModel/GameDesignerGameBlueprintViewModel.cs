using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Database;
using GDCui.Helpers;
using GDCui.Model;

namespace GDCui.ViewModel
{
    public class GameDesignerGameBlueprintViewModel : BindableBase
    {
        // combo box values
        public ObservableCollection<string> GameBlueprintNames { get; set; }
        public ObservableCollection<string> GameDesignerNames { get; set; }

        // table list and selected element
        private ObservableCollection<RelModel> gameBlueprintGameDesigners;
        public ObservableCollection<RelModel> GameBlueprintGameDesigners
        {
            get { return gameBlueprintGameDesigners; }
            set
            {
                if (value != gameBlueprintGameDesigners)
                {
                    gameBlueprintGameDesigners = value;
                    OnPropertyChanged("GameBlueprintGameDesigners");
                }
            }
        }

        private RelModel selectedGameBlueprintGameDesigner = null;
        public RelModel SelectedGameBlueprintGameDesigner
        {
            get { return selectedGameBlueprintGameDesigner; }
            set
            {
                if (selectedGameBlueprintGameDesigner != value)
                {
                    selectedGameBlueprintGameDesigner = value;
                    OnPropertyChanged("SelectedGameBlueprintGameDesigner");

                    SelectedGameBlueprintGameDesignerGameDesigner = selectedGameBlueprintGameDesigner.Name2;
                }
            }
        }

        // combo box picked
        private string selectedGameBlueprint;
        public string SelectedGameBlueprint
        {
            get { return selectedGameBlueprint; }
            set
            {
                if (selectedGameBlueprint != value)
                {
                    selectedGameBlueprint = value;
                    OnPropertyChanged("SelectedGameBlueprint");
                }
            }
        }

        private string selectedGameDesigner;
        public string SelectedGameDesigner
        {
            get { return selectedGameDesigner; }
            set
            {
                if (selectedGameDesigner != value)
                {
                    selectedGameDesigner = value;
                    OnPropertyChanged("SelectedGameDesigner");
                }
            }
        }


        // combo box update
        private string selectedGameBlueprintGameDesignerGameDesigner;
        public string SelectedGameBlueprintGameDesignerGameDesigner
        {
            get { return selectedGameBlueprintGameDesignerGameDesigner; }
            set
            {
                if (selectedGameBlueprintGameDesignerGameDesigner != value)
                {
                    selectedGameBlueprintGameDesignerGameDesigner = value;
                    OnPropertyChanged("SelectedGameBlueprintGameDesignerGameDesigner");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }

        public MyICommand UpdateCommand { get; set; }

        public GameDesignerGameBlueprintViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            GameBlueprintGameDesigners = ReadGameBlueprintGameDesigners();
            GameBlueprintNames = ReadGameBlueprintNames();
            GameDesignerNames = ReadGameDesignerNames();
        }


        // command methods
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var gameBlueprint = db.GameBlueprints.SingleOrDefault(b => b.Name == SelectedGameBlueprint);
                    var gameDesigner = db.Employees.SingleOrDefault(b => b.First_name == SelectedGameDesigner);

                    gameBlueprint.GameDesigners.Add((GameDesigner)gameDesigner);

                    db.SaveChanges();

                    GameBlueprintGameDesigners = ReadGameBlueprintGameDesigners();
                }
            }
            
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.GameBlueprints.SingleOrDefault(b => b.Name == selectedGameBlueprintGameDesigner.Name1);
                    result.GameDesigners.Clear();

                    db.SaveChanges();
                    GameBlueprintGameDesigners = ReadGameBlueprintGameDesigners();
                }
            }

        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var gameBlueprint = db.GameBlueprints.SingleOrDefault(b => b.Name == selectedGameBlueprintGameDesigner.Name1);
                    var gameDesigner = db.Employees.SingleOrDefault(b => b.First_name == selectedGameBlueprintGameDesignerGameDesigner);

                    gameBlueprint.GameDesigners.Clear();
                    gameBlueprint.GameDesigners.Add((GameDesigner)gameDesigner);

                    db.SaveChanges();
                    GameBlueprintGameDesigners = ReadGameBlueprintGameDesigners();
                }
            }

        }


        // read stuff
        private ObservableCollection<RelModel> ReadGameBlueprintGameDesigners()
        {
            ObservableCollection<RelModel> gameBlueprints = new ObservableCollection<RelModel>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.GameBlueprints)
                {
                    if (item.GameDesigners.Count > 0)
                        gameBlueprints.Add(new RelModel { Name1 = item.Name, Name2 = item.GameDesigners.ToList()[0].First_name });
                }

                return gameBlueprints;
            }
        }

        private ObservableCollection<string> ReadGameBlueprintNames()
        {
            ObservableCollection<string> gameBlueprints = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.GameBlueprints)
                {
                    if (item.GameDesigners.Count == 0)
                        gameBlueprints.Add(item.Name);
                }

                return gameBlueprints;
            }
        }

        private ObservableCollection<string> ReadGameDesignerNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Employees)
                {
                    if(item is GameDesigner)
                        names.Add(item.First_name);
                }

                return names;
            }
        }


        //validate
        private bool ValidateAdd()
        {

            if (SelectedGameBlueprint == null)
            {
                MessageBox.Show("Select a blueprint!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedGameDesigner == null)
            {
                MessageBox.Show("Select a designer!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private bool ValidateUpdate()
        {
            if (SelectedGameBlueprintGameDesigner == null)
            {
                MessageBox.Show("Select an item", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else if (SelectedGameBlueprintGameDesignerGameDesigner == null)
            {
                MessageBox.Show("Select a designer!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedGameBlueprintGameDesigner == null)
            {
                MessageBox.Show("Select an item!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
