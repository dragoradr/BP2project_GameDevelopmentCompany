using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Database;
using GDCui.Helpers;

namespace GDCui.ViewModel
{
    public class GameBlueprintViewModel : BindableBase
    {
        public ObservableCollection<GameBlueprint> blueprints;
        public ObservableCollection<GameBlueprint> Blueprints
        {
            get { return blueprints; }
            set
            {
                if (blueprints != value)
                {
                    blueprints = value;
                    OnPropertyChanged("Blueprints");
                }
            }
        }

        private GameBlueprint selectedBlueprint { get; set; }
        public GameBlueprint SelectedBlueprint
        {
            get { return selectedBlueprint; }
            set
            {
                if (selectedBlueprint != value)
                {
                    selectedBlueprint = value;
                    OnPropertyChanged("SelectedBlueprint");

                    SelectedBlueprintName = selectedBlueprint.Name;
                }
            }
        }

        //blueprint properties
        private string nameText;
        public string NameText
        {
            get { return nameText; }
            set
            {
                if (nameText != value)
                {
                    nameText = value;
                    OnPropertyChanged("NameText");
                }
            }
        }


        //blueprint update properties
        private string selectedBlueprintName;
        public string SelectedBlueprintName
        {
            get { return selectedBlueprintName; }
            set
            {
                if (selectedBlueprintName != value)
                {
                    selectedBlueprintName = value;
                    OnPropertyChanged("SelectedBlueprintName");
                }
            }
        }

        //commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public GameBlueprintViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            Blueprints = ReadBlueprints();
        }



        //helps
        private ObservableCollection<GameBlueprint> ReadBlueprints()
        {
            using (var db = new GDCdbContext())
            {
                return new ObservableCollection<GameBlueprint>(db.GameBlueprints);
            }
        }

        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {

                    var blueprint = new GameBlueprint
                    {
                        Name = NameText,

                    };

                    db.GameBlueprints.Add(blueprint);
                    db.SaveChanges();

                    Blueprints = new ObservableCollection<GameBlueprint>(db.GameBlueprints);

                }
            }
            
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    db.GameBlueprints.Attach(SelectedBlueprint);
                    db.GameBlueprints.Remove(SelectedBlueprint);

                    db.SaveChanges();
                    Blueprints = new ObservableCollection<GameBlueprint>(db.GameBlueprints);
                }
            }
            
        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.GameBlueprints.SingleOrDefault(b => b.Blu_Id == selectedBlueprint.Blu_Id);

                    if (result != null)
                    {
                        result.Name = selectedBlueprintName;

                        db.SaveChanges();
                        Blueprints = new ObservableCollection<GameBlueprint>(db.GameBlueprints);
                    }
                }
            }
           
        }


        //validation
        private bool ValidateAdd()
        {

            if (NameText == null || NameText == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NameExists(NameText))
            {
                MessageBox.Show("Blueprint with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateUpdate()
        {
            if (SelectedBlueprint == null)
            {
                MessageBox.Show("Select a blueprint!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedBlueprintName == null || SelectedBlueprintName == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NameExists(SelectedBlueprintName))
            {
                MessageBox.Show("Blueprint with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private bool ValidateDelete()
        {
            if (SelectedBlueprint == null)
            {
                MessageBox.Show("Select a blueprint!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool NameExists(string name)
        {
            using (var db = new GDCdbContext())
            {
                var result = db.GameBlueprints.SingleOrDefault(b => b.Name == name);

                if (result == null)
                    return false;

                return true;
            }
        }

    }
}
