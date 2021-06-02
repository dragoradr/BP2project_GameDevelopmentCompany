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
    public class CodeViewModel : BindableBase
    {
        private ObservableCollection<Code> codes;
        public ObservableCollection<Code> Codes
        {
            get { return codes; }
            set
            {
                if (codes != value)
                {
                    codes = value;
                    OnPropertyChanged("Codes");
                }
            }
        }


        private Code selectedCode { get; set; }
        public Code SelectedCode
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


        //code properties
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


        //code update properties
        private string selectedCodeName;
        public string SelectedCodeName
        {
            get { return selectedCodeName; }
            set
            {
                if (selectedCodeName != value)
                {
                    selectedCodeName = value;
                    OnPropertyChanged("SelectedCodeName");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }


        public CodeViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            Codes = ReadCodes();
        }



        //helps
        private ObservableCollection<Code> ReadCodes()
        {
            using (var db = new GDCdbContext())
            {
                return new ObservableCollection<Code>(db.Codes);
            }
        }

        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {

                    var code = new Code
                    {
                        Name = NameText,

                    };

                    db.Codes.Add(code);
                    db.SaveChanges();

                    Codes = new ObservableCollection<Code>(db.Codes);

                }
            }
           
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    db.Codes.Attach(SelectedCode);
                    db.Codes.Remove(SelectedCode);

                    db.SaveChanges();
                    Codes = new ObservableCollection<Code>(db.Codes);
                }
            }
            
        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Codes.SingleOrDefault(b => b.Code_Id == selectedCode.Code_Id);

                    if (result != null)
                    {
                        result.Name = selectedCodeName;

                        db.SaveChanges();
                        Codes = new ObservableCollection<Code>(db.Codes);
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
                MessageBox.Show("Code with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateUpdate()
        {
            if (SelectedCode == null)
            {
                MessageBox.Show("Select a code!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedCodeName == null || SelectedCodeName == "")
            {
                MessageBox.Show("Enter a code!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NameExists(SelectedCodeName))
            {
                MessageBox.Show("Code with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private bool ValidateDelete()
        {
            if (SelectedCode == null)
            {
                MessageBox.Show("Select a code!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool NameExists(string name)
        {
            using (var db = new GDCdbContext())
            {
                var result = db.Codes.SingleOrDefault(b => b.Name == name);

                if (result == null)
                    return false;

                return true;
            }
        }
    }
}
