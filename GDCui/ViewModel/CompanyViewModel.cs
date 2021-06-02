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
    public class CompanyViewModel : BindableBase
    {
        public ObservableCollection<GameDevelopmentCompany> companies;
        public ObservableCollection<GameDevelopmentCompany> Companies
        {
            get { return companies; }
            set
            {
                if (companies != value)
                {
                    companies = value;
                    OnPropertyChanged("Companies");
                }
            }
        }

        private GameDevelopmentCompany selectedCompany { get; set; }

        private string selectedCompanyName;
        public GameDevelopmentCompany SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                if (selectedCompany != value)
                {
                    selectedCompany = value;
                    OnPropertyChanged("SelectedCompany");

                    SelectedCompanyName = selectedCompany.Name.ToString();
                }


            }
        }

        public string SelectedCompanyName
        {
            get { return selectedCompanyName; }
            set
            {
                if (selectedCompanyName != value)
                {
                    selectedCompanyName = value;
                    OnPropertyChanged("SelectedCompanyName");
                }


            }
        }

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

        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public CompanyViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            Companies = ReadCompanies();
        }


        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {

                    var company = new GameDevelopmentCompany
                    {
                        Name = NameText,
                    };

                    db.GameDevelopmentCompanies.Add(company);
                    db.SaveChanges();

                    Companies = ReadCompanies();

                }
            }
            
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    db.GameDevelopmentCompanies.Attach(SelectedCompany);
                    db.GameDevelopmentCompanies.Remove(SelectedCompany);

                    db.SaveChanges();
                    Companies = ReadCompanies();
                }

            }
        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.GameDevelopmentCompanies.SingleOrDefault(b => b.Company_Id == selectedCompany.Company_Id);

                    if (result != null)
                    {
                        result.Name = selectedCompanyName;
                        db.SaveChanges();
                        Companies = ReadCompanies();
                    }
                }
            }
            
        }

        private ObservableCollection<GameDevelopmentCompany> ReadCompanies()
        {
            using (var db = new GDCdbContext())
            {
                return new ObservableCollection<GameDevelopmentCompany>(db.GameDevelopmentCompanies);
            }
        }

        private bool ValidateAdd()
        {

            if (NameText == null || NameText == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NameExists(NameText))
            {
                MessageBox.Show("Company with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            
            return true;
        }

        private bool ValidateUpdate()
        {
            if (SelectedCompany == null)
            {
                MessageBox.Show("Select a company!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedCompanyName == null || SelectedCompanyName == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NameExists(SelectedCompanyName))
            {
                MessageBox.Show("Company with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private bool ValidateDelete()
        {
            if (SelectedCompany == null)
            {
                MessageBox.Show("Select a company!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool NameExists(string name)
        {
            using (var db = new GDCdbContext())
            {
                var result = db.GameDevelopmentCompanies.SingleOrDefault(b => b.Name == name);

                if (result == null)
                    return false;

                return true;
            }
        }
    }
}
