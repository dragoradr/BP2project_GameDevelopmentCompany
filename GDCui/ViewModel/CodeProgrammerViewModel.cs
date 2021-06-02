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
    public class CodeProgrammerViewModel : BindableBase
    {
        // combo box values
        public ObservableCollection<string> CodeNames { get; set; }
        public ObservableCollection<string> ProgrammerNames { get; set; }

        // table list and selected element
        private ObservableCollection<RelModel> codeProgrammers;
        public ObservableCollection<RelModel> CodeProgrammers
        {
            get { return codeProgrammers; }
            set
            {
                if (value != codeProgrammers)
                {
                    codeProgrammers = value;
                    OnPropertyChanged("CodeProgrammers");
                }
            }
        }

        private RelModel selectedCodeProgrammer = new RelModel();
        public RelModel SelectedCodeProgrammer
        {
            get { return selectedCodeProgrammer; }
            set
            {
                if (selectedCodeProgrammer != value)
                {
                    selectedCodeProgrammer = value;
                    OnPropertyChanged("SelectedCodeProgrammer");

                    SelectedCodeProgrammerProgrammer = selectedCodeProgrammer.Name2;
                }
            }
        }

        // combo box picked
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

        private string selectedProgrammer;
        public string SelectedProgrammer
        {
            get { return selectedProgrammer; }
            set
            {
                if (selectedProgrammer != value)
                {
                    selectedProgrammer = value;
                    OnPropertyChanged("SelectedProgrammer");
                }
            }
        }


        // combo box update
        private string selectedCodeProgrammerProgrammer;
        public string SelectedCodeProgrammerProgrammer
        {
            get { return selectedCodeProgrammerProgrammer; }
            set
            {
                if (selectedCodeProgrammerProgrammer != value)
                {
                    selectedCodeProgrammerProgrammer = value;
                    OnPropertyChanged("SelectedCodeProgrammerProgrammer");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public CodeProgrammerViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            CodeProgrammers = ReadCodeProgrammers();
            CodeNames = ReadCodeNames();
            ProgrammerNames = ReadProgrammerNames();
        }


        // command methods
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var code = db.Codes.SingleOrDefault(b => b.Name == SelectedCode);
                    var programmer = db.Employees.SingleOrDefault(b => b.First_name == SelectedProgrammer);

                    code.Programmers.Add((Programmer)programmer);

                    db.SaveChanges();

                    CodeProgrammers = ReadCodeProgrammers();
                }
            }

        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Codes.SingleOrDefault(b => b.Name == selectedCodeProgrammer.Name1);
                    result.Programmers.Clear();

                    db.SaveChanges();
                    CodeProgrammers = ReadCodeProgrammers();
                }
            }

        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var code = db.Codes.SingleOrDefault(b => b.Name == selectedCodeProgrammer.Name1);
                    var programmer = db.Employees.SingleOrDefault(b => b.First_name == selectedCodeProgrammerProgrammer);

                    code.Programmers.Clear();
                    code.Programmers.Add((Programmer)programmer);

                    db.SaveChanges();
                    CodeProgrammers = ReadCodeProgrammers();
                }
            }

        }


        // read stuff
        private ObservableCollection<RelModel> ReadCodeProgrammers()
        {
            ObservableCollection<RelModel> codes = new ObservableCollection<RelModel>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Codes)
                {
                    if (item.Programmers.Count > 0)
                        codes.Add(new RelModel { Name1 = item.Name, Name2 = item.Programmers.ToList()[0].First_name });
                }

                return codes;
            }
        }

        private ObservableCollection<string> ReadCodeNames()
        {
            ObservableCollection<string> codes = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Codes)
                {
                    if (item.Programmers.Count == 0)
                        codes.Add(item.Name);
                }

                return codes;
            }
        }

        private ObservableCollection<string> ReadProgrammerNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Employees)
                {
                    if (item is Programmer)
                        names.Add(item.First_name);
                }

                return names;
            }
        }

        private bool ValidateAdd()
        {

            if (SelectedProgrammer == null)
            {
                MessageBox.Show("Select a programmer!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (SelectedCodeProgrammer == null)
            {
                MessageBox.Show("Select an item", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else if (SelectedCodeProgrammerProgrammer == null)
            {
                MessageBox.Show("Select a programmer!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedCodeProgrammer == null)
            {
                MessageBox.Show("Select an item!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
