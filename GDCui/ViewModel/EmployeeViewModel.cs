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
    public class EmployeeViewModel : BindableBase
    {
        

        public ObservableCollection<string> CompanyNames { get; set; }
        public ObservableCollection<string> Positions { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }

        
        public ObservableCollection<Employee> employees { get; set; }
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                if (employees != value)
                {
                    employees = value;
                    OnPropertyChanged("Employees");
                }
            }
        }


        // Selected employee
        private Employee selectedEmployee = null;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;
                    OnPropertyChanged("SelectedEmployee");
                    SelectedEmployeeFirstName = selectedEmployee.First_name;
                    SelectedEmployeeLastName = selectedEmployee.Last_name;
                    SelectedEmployeeCompany = GetCompanyName(selectedEmployee.GameDevelopmentCompanyCompany_Id);
                    SelectedEmployeePosition = selectedEmployee.Position;
                }
            }
        }

        private string selectedEmployeeFirstName { get; set; }
        public string SelectedEmployeeFirstName
        {
            get { return selectedEmployeeFirstName; }
            set
            {
                if (selectedEmployeeFirstName != value)
                {
                    selectedEmployeeFirstName = value;
                    OnPropertyChanged("SelectedEmployeeFirstName");
                }
            }
        }

        private string selectedEmployeeLastName { get; set; }
        public string SelectedEmployeeLastName
        {
            get { return selectedEmployeeLastName; }
            set
            {
                if (selectedEmployeeLastName != value)
                {
                    selectedEmployeeLastName = value;
                    OnPropertyChanged("SelectedEmployeeLastName");
                }
            }
        }

        private string selectedEmployeeCompany { get; set; }
        public string SelectedEmployeeCompany
        {
            get { return selectedEmployeeCompany; }
            set
            {
                if (selectedEmployeeCompany != value)
                {
                    selectedEmployeeCompany = value;
                    OnPropertyChanged("SelectedEmployeeCompany");
                }
            }
        }

        private string selectedEmployeePosition { get; set; }
        public string SelectedEmployeePosition
        {
            get { return selectedEmployeePosition; }
            set
            {
                if (selectedEmployeePosition != value)
                {
                    selectedEmployeePosition = value;
                    OnPropertyChanged("SelectedEmployeePosition");
                }
            }
        }

        private string selectedCompany;
        public string SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                if (selectedCompany != value)
                {
                    selectedCompany = value;
                    OnPropertyChanged("SelectedCompany");
                }
            }
        }

        private string selectedPosition;
        public string SelectedPosition
        {
            get { return selectedPosition; }
            set
            {
                if (selectedPosition != value)
                {
                    selectedPosition = value;
                    OnPropertyChanged("SelectedPosition");
                }
            }
        }

        private string firstNameText;
        public string FirstNameText
        {
            get { return firstNameText; }
            set
            {
                if (firstNameText != value)
                {
                    firstNameText = value;
                    OnPropertyChanged("FirstNameText");
                }
            }
        }

        private string lastNameText;
        public string LastNameText
        {
            get { return lastNameText; }
            set
            {
                if (lastNameText != value)
                {
                    lastNameText = value;
                    OnPropertyChanged("LastNameText");
                }
            }
        }

        public EmployeeViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            UpdateCommand = new MyICommand(OnUpdate);
            DeleteCommand = new MyICommand(OnDelete);
            CompanyNames = ReadCompanies();
            Employees = ReadEmployees();
            Positions = ReadPositions();
        }

        private ObservableCollection<string> ReadCompanies()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.GameDevelopmentCompanies)
                {
                    names.Add(item.Name);
                }

                return names;
            }
        }

        private ObservableCollection<Employee> ReadEmployees()
        {
            ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Employees)
                {
                    emp.Add(item);
                }

                return emp;
            }
        }

        
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {

                    switch (SelectedPosition)
                    {
                        case "GameDesigner":
                            var gameDesigner = new GameDesigner
                            {
                                First_name = FirstNameText,
                                Last_name = LastNameText,
                                GameDevelopmentCompanyCompany_Id = GetCompanyId(selectedCompany),
                                Position = "Game designer"
                            };
                            db.Employees.Add(gameDesigner);
                            db.SaveChanges();
                            Employees = ReadEmployees();
                            break;
                        case "Programmer":
                            var programmer = new Programmer
                            {
                                First_name = FirstNameText,
                                Last_name = LastNameText,
                                GameDevelopmentCompanyCompany_Id = GetCompanyId(selectedCompany),
                                Position = "Programmer"
                            };
                            db.Employees.Add(programmer);
                            db.SaveChanges();
                            Employees = ReadEmployees();
                            break;
                        case "Artist":
                            var artist = new Artist
                            {
                                First_name = FirstNameText,
                                Last_name = LastNameText,
                                GameDevelopmentCompanyCompany_Id = GetCompanyId(selectedCompany),
                                Position = "Artist"
                            };
                            db.Employees.Add(artist);
                            db.SaveChanges();
                            Employees = ReadEmployees();
                            break;
                        case "Tester":
                            var tester = new Tester
                            {
                                First_name = FirstNameText,
                                Last_name = LastNameText,
                                GameDevelopmentCompanyCompany_Id = GetCompanyId(selectedCompany),
                                Position = "Tester"
                            };
                            db.Employees.Add(tester);
                            db.SaveChanges();
                            Employees = ReadEmployees();
                            break;
                    }
                }
            }
            
        }

        
        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    db.Employees.Attach(SelectedEmployee);
                    db.Employees.Remove(SelectedEmployee);

                    db.SaveChanges();
                    Employees = ReadEmployees();
                }
            }
            
        }

        
        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Employees.SingleOrDefault(b => b.Employee_Id == selectedEmployee.Employee_Id);

                    if (result != null)
                    {
                        result.First_name = selectedEmployeeFirstName;
                        result.Last_name = selectedEmployeeLastName;
                        result.GameDevelopmentCompanyCompany_Id = GetCompanyId(selectedEmployeeCompany);
                        result.Position = selectedEmployeePosition;
                        db.SaveChanges();
                        Employees = ReadEmployees();
                    }
                }
            }        
        }

        

        private int GetCompanyId(string selectedCompanyName)
        {
            using (var db = new GDCdbContext())
            {
                var result = db.GameDevelopmentCompanies.SingleOrDefault(b => b.Name == selectedCompanyName);

                return result.Company_Id;
            }

        }

        private string GetCompanyName(int selectedId)
        {
            using (var db = new GDCdbContext())
            {
                var result = db.GameDevelopmentCompanies.SingleOrDefault(b => b.Company_Id == selectedId);

                return result.Name;
            }

        }

        private ObservableCollection<string> ReadPositions()
        {
            ObservableCollection<string> pos = new ObservableCollection<string>
            {
                "GameDesigner",
                "Programmer",
                "Artist",
                "Tester"
            };

            return pos;
        }

        //validation
        private bool ValidateAdd()
        {

            if (FirstNameText == null || FirstNameText == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (LastNameText == null || LastNameText == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedCompany == null)
            {
                MessageBox.Show("Select a company!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedPosition == null)
            {
                MessageBox.Show("Select a position!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        
        private bool ValidateUpdate()
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("Select an employee", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedEmployeeFirstName == null || SelectedEmployeeFirstName == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedEmployeeLastName == null || SelectedEmployeeLastName == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedEmployeeCompany == null)
            {
                MessageBox.Show("Select a company!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedEmployeePosition == null)
            {
                MessageBox.Show("Select a position!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        
        private bool ValidateDelete()
        {
            if (SelectedEmployee == null)
            {
                MessageBox.Show("Select an employee!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
