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
    public class ArtTesterViewModel : BindableBase
    {
        // combo box values
        public ObservableCollection<string> ArtNames { get; set; }
        public ObservableCollection<string> TesterNames { get; set; }

        // table list and selected element
        private ObservableCollection<RelModel> artTesters;
        public ObservableCollection<RelModel> ArtTesters
        {
            get { return artTesters; }
            set
            {
                if (value != artTesters)
                {
                    artTesters = value;
                    OnPropertyChanged("ArtTesters");
                }
            }
        }

        private RelModel selectedArtTester = null;
        public RelModel SelectedArtTester
        {
            get { return selectedArtTester; }
            set
            {
                if (selectedArtTester != value)
                {
                    selectedArtTester = value;
                    OnPropertyChanged("SelectedArtTester");

                    SelectedArtTesterTester = selectedArtTester.Name2;
                }
            }
        }

        // combo box picked
        private string selectedArt;
        public string SelectedArt
        {
            get { return selectedArt; }
            set
            {
                if (selectedArt != value)
                {
                    selectedArt = value;
                    OnPropertyChanged("SelectedArt");
                }
            }
        }

        private string selectedTester;
        public string SelectedTester
        {
            get { return selectedTester; }
            set
            {
                if (selectedTester != value)
                {
                    selectedTester = value;
                    OnPropertyChanged("SelectedTester");
                }
            }
        }


        // combo box update
        private string selectedArtTesterTester;
        public string SelectedArtTesterTester
        {
            get { return selectedArtTesterTester; }
            set
            {
                if (selectedArtTesterTester != value)
                {
                    selectedArtTesterTester = value;
                    OnPropertyChanged("SelectedArtTesterTester");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public ArtTesterViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            ArtTesters = ReadArtTesters();
            ArtNames = ReadArtNames();
            TesterNames = ReadTesterNames();
        }


        // command methods
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var art = db.Arts.SingleOrDefault(b => b.Name == SelectedArt);
                    var tester = db.Employees.SingleOrDefault(b => b.First_name == SelectedTester);

                    art.Testers.Add((Tester)tester);

                    db.SaveChanges();

                    ArtTesters = ReadArtTesters();
                }
            }

        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Arts.SingleOrDefault(b => b.Name == selectedArtTester.Name1);
                    result.Testers.Clear();

                    db.SaveChanges();
                    ArtTesters = ReadArtTesters();
                }
            }

        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var art = db.Arts.SingleOrDefault(b => b.Name == selectedArtTester.Name1);
                    var tester = db.Employees.SingleOrDefault(b => b.First_name == selectedArtTesterTester);

                    art.Testers.Clear();
                    art.Testers.Add((Tester)tester);

                    db.SaveChanges();
                    ArtTesters = ReadArtTesters();
                }
            }
            
        }


        // read stuff
        private ObservableCollection<RelModel> ReadArtTesters()
        {
            ObservableCollection<RelModel> arts = new ObservableCollection<RelModel>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Arts)
                {
                    if (item.Testers.Count > 0)
                        arts.Add(new RelModel { Name1 = item.Name, Name2 = item.Testers.ToList()[0].First_name });
                }

                return arts;
            }
        }

        private ObservableCollection<string> ReadArtNames()
        {
            ObservableCollection<string> arts = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Arts)
                {
                    if (item.Testers.Count == 0)
                        arts.Add(item.Name);
                }

                return arts;
            }
        }

        private ObservableCollection<string> ReadTesterNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Employees)
                {
                    if (item is Tester)
                        names.Add(item.First_name);
                }

                return names;
            }
        }


        //validation
        private bool ValidateAdd()
        {

            if (SelectedArt == null)
            {
                MessageBox.Show("Select an art!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedTester == null)
            {
                MessageBox.Show("Select a tester!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private bool ValidateUpdate()
        {
            if (SelectedArtTester == null)
            {
                MessageBox.Show("Select an item", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else if (SelectedArtTesterTester == null)
            {
                MessageBox.Show("Select an tester!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedArtTester == null)
            {
                MessageBox.Show("Select an item!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
