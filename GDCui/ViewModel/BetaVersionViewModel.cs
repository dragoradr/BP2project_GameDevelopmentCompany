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
    public class BetaVersionViewModel : BindableBase
    {
        private ObservableCollection<BetaVersion> betaVersions;
        public ObservableCollection<BetaVersion> BetaVersions
        {
            get { return betaVersions; }
            set
            {
                if (betaVersions != value)
                {
                    betaVersions = value;
                    OnPropertyChanged("BetaVersions");
                }
            }
        }


        private BetaVersion selectedBeta { get; set; }
        public BetaVersion SelectedBeta
        {
            get { return selectedBeta; }
            set
            {
                if (selectedBeta != value)
                {
                    selectedBeta = value;
                    OnPropertyChanged("SelectedBeta");
                }
            }
        }


        //beta properties
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


        //beta update properties
        private string selectedBetaName;
        public string SelectedBetaName
        {
            get { return selectedBetaName; }
            set
            {
                if (selectedBetaName != value)
                {
                    selectedBetaName = value;
                    OnPropertyChanged("SelectedBetaName");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }


        public BetaVersionViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            BetaVersions = ReadBetas();
        }



        //helps
        private ObservableCollection<BetaVersion> ReadBetas()
        {
            using (var db = new GDCdbContext())
            {
                return new ObservableCollection<BetaVersion>(db.BetaVersions);
            }
        }

        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {

                    var beta = new BetaVersion
                    {
                        Name = NameText,

                    };

                    db.BetaVersions.Add(beta);
                    db.SaveChanges();

                    BetaVersions = new ObservableCollection<BetaVersion>(db.BetaVersions);

                }
            }
            
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    db.BetaVersions.Attach(SelectedBeta);
                    db.BetaVersions.Remove(SelectedBeta);

                    db.SaveChanges();
                    BetaVersions = new ObservableCollection<BetaVersion>(db.BetaVersions);
                }
            }
            
        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.BetaVersions.SingleOrDefault(b => b.Beta_Id == selectedBeta.Beta_Id);

                    if (result != null)
                    {
                        result.Name = selectedBetaName;

                        db.SaveChanges();
                        BetaVersions = new ObservableCollection<BetaVersion>(db.BetaVersions);
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
                MessageBox.Show("BetaVersion with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateUpdate()
        {
            if (SelectedBeta == null)
            {
                MessageBox.Show("Select a beta!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedBetaName == null || SelectedBetaName == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NameExists(SelectedBetaName))
            {
                MessageBox.Show("Beta with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private bool ValidateDelete()
        {
            if (SelectedBeta == null)
            {
                MessageBox.Show("Select a beta!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool NameExists(string name)
        {
            using (var db = new GDCdbContext())
            {
                var result = db.BetaVersions.SingleOrDefault(b => b.Name == name);

                if (result == null)
                    return false;

                return true;
            }
        }
    }
}
