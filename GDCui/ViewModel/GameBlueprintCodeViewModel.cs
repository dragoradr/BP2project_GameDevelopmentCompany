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
    public class GameBlueprintCodeViewModel : BindableBase
    {
        // combo box values
        public ObservableCollection<string> GameBlueprintNames { get; set; }
        public ObservableCollection<string> CodeNames { get; set; }

        // table list and selected element
        private ObservableCollection<RelModel> gameBlueprintCodes;
        public ObservableCollection<RelModel> GameBlueprintCodes
        {
            get { return gameBlueprintCodes; }
            set
            {
                if (value != gameBlueprintCodes)
                {
                    gameBlueprintCodes = value;
                    OnPropertyChanged("GameBlueprintCodes");
                }
            }
        }

        private RelModel selectedGameBlueprintCode = null;
        public RelModel SelectedGameBlueprintCode
        {
            get { return selectedGameBlueprintCode; }
            set
            {
                if (selectedGameBlueprintCode != value)
                {
                    selectedGameBlueprintCode = value;
                    OnPropertyChanged("SelectedGameBlueprintCode");

                    SelectedGameBlueprintCodeCode = selectedGameBlueprintCode.Name2;
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

        private string selectedCode;
        public string SelectedCode
        {
            get { return selectedCode; }
            set
            {
                if (selectedCode != value)
                {
                    selectedCode = value;
                    OnPropertyChanged("SelectedCode");
                }
            }
        }


        // combo box update
        private string selectedGameBlueprintCodeCode;
        public string SelectedGameBlueprintCodeCode
        {
            get { return selectedGameBlueprintCodeCode; }
            set
            {
                if (selectedGameBlueprintCodeCode != value)
                {
                    selectedGameBlueprintCodeCode = value;
                    OnPropertyChanged("SelectedGameBlueprintCodeCode");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public GameBlueprintCodeViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            GameBlueprintCodes = ReadGameBlueprintCodes();
            GameBlueprintNames = ReadGameBlueprintNames();
            CodeNames = ReadCodeNames();
        }


        // command methods
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var gameBlueprint = db.GameBlueprints.SingleOrDefault(b => b.Name == SelectedGameBlueprint);
                    var code = db.Codes.SingleOrDefault(b => b.Name == SelectedCode);

                    gameBlueprint.Codes.Add(code);

                    db.SaveChanges();

                    GameBlueprintCodes = ReadGameBlueprintCodes();
                }
            }

        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.GameBlueprints.SingleOrDefault(b => b.Name == selectedGameBlueprintCode.Name1);
                    result.Codes.Clear();

                    db.SaveChanges();
                    GameBlueprintCodes = ReadGameBlueprintCodes();
                }
            }

        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var gameBlueprint = db.GameBlueprints.SingleOrDefault(b => b.Name == selectedGameBlueprintCode.Name1);
                    var code = db.Codes.SingleOrDefault(b => b.Name == selectedGameBlueprintCodeCode);

                    gameBlueprint.Codes.Clear();
                    gameBlueprint.Codes.Add(code);

                    db.SaveChanges();
                    GameBlueprintCodes = ReadGameBlueprintCodes();
                }
            }

        }


        // read stuff
        private ObservableCollection<RelModel> ReadGameBlueprintCodes()
        {
            ObservableCollection<RelModel> gameBlueprints = new ObservableCollection<RelModel>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.GameBlueprints)
                {
                    if (item.Codes.Count > 0)
                        gameBlueprints.Add(new RelModel { Name1 = item.Name, Name2 = item.Codes.ToList()[0].Name });
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
                    if (item.Codes.Count == 0)
                        gameBlueprints.Add(item.Name);
                }

                return gameBlueprints;
            }
        }

        private ObservableCollection<string> ReadCodeNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Codes)
                {
                    names.Add(item.Name);
                }

                return names;
            }
        }

        private bool ValidateAdd()
        {

            if (SelectedGameBlueprint == null)
            {
                MessageBox.Show("Select a blueprint!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedCode == null)
            {
                MessageBox.Show("Select a code!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private bool ValidateUpdate()
        {
            if (SelectedGameBlueprintCode == null)
            {
                MessageBox.Show("Select an item", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else if (SelectedGameBlueprintCodeCode == null)
            {
                MessageBox.Show("Select a code!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedGameBlueprintCode == null)
            {
                MessageBox.Show("Select an item!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
