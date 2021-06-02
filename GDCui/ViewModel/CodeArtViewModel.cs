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
    public class CodeArtViewModel : BindableBase
    {
        // combo box values
        public ObservableCollection<string> CodeNames { get; set; }
        public ObservableCollection<string> ArtNames { get; set; }

        // table list and selected element
        private ObservableCollection<RelModel> codeArts;
        public ObservableCollection<RelModel> CodeArts
        {
            get { return codeArts; }
            set
            {
                if (value != codeArts)
                {
                    codeArts = value;
                    OnPropertyChanged("CodeArts");
                }
            }
        }

        private RelModel selectedCodeArt = null;
        public RelModel SelectedCodeArt
        {
            get { return selectedCodeArt; }
            set
            {
                if (selectedCodeArt != value)
                {
                    selectedCodeArt = value;
                    OnPropertyChanged("SelectedCodeArt");

                    SelectedCodeArtArt = selectedCodeArt.Name2;
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


        // combo box update
        private string selectedCodeArtArt;
        public string SelectedCodeArtArt
        {
            get { return selectedCodeArtArt; }
            set
            {
                if (selectedCodeArtArt != value)
                {
                    selectedCodeArtArt = value;
                    OnPropertyChanged("SelectedCodeArtArt");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public CodeArtViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            CodeArts = ReadCodeArts();
            CodeNames = ReadCodeNames();
            ArtNames = ReadArtNames();
        }


        // command methods
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var code = db.Codes.SingleOrDefault(b => b.Name == SelectedCode);
                    var art = db.Arts.SingleOrDefault(b => b.Name == SelectedArt);

                    code.Arts.Add(art);

                    db.SaveChanges();

                    CodeArts = ReadCodeArts();
                }
            }
            
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Codes.SingleOrDefault(b => b.Name == selectedCodeArt.Name1);
                    result.Arts.Clear();

                    db.SaveChanges();
                    CodeArts = ReadCodeArts();
                }
            }

        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var code = db.Codes.SingleOrDefault(b => b.Name == selectedCodeArt.Name1);
                    var art = db.Arts.SingleOrDefault(b => b.Name == selectedCodeArtArt);

                    code.Arts.Clear();
                    code.Arts.Add(art);

                    db.SaveChanges();
                    CodeArts = ReadCodeArts();
                }
            }

        }


        // read stuff
        private ObservableCollection<RelModel> ReadCodeArts()
        {
            ObservableCollection<RelModel> codes = new ObservableCollection<RelModel>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Codes)
                {
                    if (item.Arts.Count > 0)
                        codes.Add(new RelModel { Name1 = item.Name, Name2 = item.Arts.ToList()[0].Name });
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
                    if (item.Arts.Count == 0)
                        codes.Add(item.Name);
                }

                return codes;
            }
        }

        private ObservableCollection<string> ReadArtNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Arts)
                {
                     names.Add(item.Name);
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
            else if (SelectedCode == null)
            {
                MessageBox.Show("Select a code!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private bool ValidateUpdate()
        {
            if (SelectedCodeArt == null)
            {
                MessageBox.Show("Select an item", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else if (SelectedCodeArtArt == null)
            {
                MessageBox.Show("Select an art!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedCodeArt == null)
            {
                MessageBox.Show("Select an item!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
