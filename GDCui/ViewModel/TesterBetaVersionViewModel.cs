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
    public class TesterBetaVersionViewModel : BindableBase
    {
        // combo box values
        public ObservableCollection<string> BetaVersionNames { get; set; }
        public ObservableCollection<string> TesterNames { get; set; }

        // table list and selected element
        private ObservableCollection<RelModel> betaVersionTesters;
        public ObservableCollection<RelModel> BetaVersionTesters
        {
            get { return betaVersionTesters; }
            set
            {
                if (value != betaVersionTesters)
                {
                    betaVersionTesters = value;
                    OnPropertyChanged("BetaVersionTesters");
                }
            }
        }

        private RelModel selectedBetaVersionTester = new RelModel();
        public RelModel SelectedBetaVersionTester
        {
            get { return selectedBetaVersionTester; }
            set
            {
                if (selectedBetaVersionTester != value)
                {
                    selectedBetaVersionTester = value;
                    OnPropertyChanged("SelectedBetaVersionTester");

                    SelectedBetaVersionTesterTester = selectedBetaVersionTester.Name2;
                }
            }
        }

        // combo box picked
        private string selectedBetaVersion;
        public string SelectedBetaVersion
        {
            get { return selectedBetaVersion; }
            set
            {
                if (selectedBetaVersion != value)
                {
                    selectedBetaVersion = value;
                    OnPropertyChanged("SelectedBetaVersion");
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
        private string selectedBetaVersionTesterTester;
        public string SelectedBetaVersionTesterTester
        {
            get { return selectedBetaVersionTesterTester; }
            set
            {
                if (selectedBetaVersionTesterTester != value)
                {
                    selectedBetaVersionTesterTester = value;
                    OnPropertyChanged("SelectedBetaVersionTesterTester");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public TesterBetaVersionViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            BetaVersionTesters = ReadBetaVersionTesters();
            BetaVersionNames = ReadBetaVersionNames();
            TesterNames = ReadTesterNames();
        }


        // command methods
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var betaVersion = db.BetaVersions.SingleOrDefault(b => b.Name == SelectedBetaVersion);
                    var tester = db.Employees.SingleOrDefault(b => b.First_name == SelectedTester);

                    betaVersion.Testers.Add((Tester)tester);

                    db.SaveChanges();

                    BetaVersionTesters = ReadBetaVersionTesters();
                }
            }
            
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.BetaVersions.SingleOrDefault(b => b.Name == selectedBetaVersionTester.Name1);
                    result.Testers.Clear();

                    db.SaveChanges();
                    BetaVersionTesters = ReadBetaVersionTesters();
                }
            }

        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var betaVersion = db.BetaVersions.SingleOrDefault(b => b.Name == selectedBetaVersionTester.Name1);
                    var tester = db.Employees.SingleOrDefault(b => b.First_name == selectedBetaVersionTesterTester);

                    betaVersion.Testers.Clear();
                    betaVersion.Testers.Add((Tester)tester);

                    db.SaveChanges();
                    BetaVersionTesters = ReadBetaVersionTesters();
                }
            }

        }


        // read stuff
        private ObservableCollection<RelModel> ReadBetaVersionTesters()
        {
            ObservableCollection<RelModel> betaVersions = new ObservableCollection<RelModel>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.BetaVersions)
                {
                    if (item.Testers.Count > 0)
                        betaVersions.Add(new RelModel { Name1 = item.Name, Name2 = item.Testers.ToList()[0].First_name });
                }

                return betaVersions;
            }
        }

        private ObservableCollection<string> ReadBetaVersionNames()
        {
            ObservableCollection<string> betaVersions = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.BetaVersions)
                {
                    if (item.Testers.Count == 0)
                        betaVersions.Add(item.Name);
                }

                return betaVersions;
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

            if (SelectedBetaVersion == null)
            {
                MessageBox.Show("Select a beta!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (SelectedBetaVersionTester == null)
            {
                MessageBox.Show("Select an item", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else if (selectedBetaVersionTesterTester == null)
            {
                MessageBox.Show("Select a tester!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedBetaVersionTester == null)
            {
                MessageBox.Show("Select an item!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
