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
    public class ArtViewModel : BindableBase
    {
        private ObservableCollection<Art> arts;
        public ObservableCollection<Art> Arts
        {
            get { return arts; }
            set
            {
                if (arts != value)
                {
                    arts = value;
                    OnPropertyChanged("Arts");
                }
            }
        }


        private Art selectedArt { get; set; }
        public Art SelectedArt
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


        //art properties
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


        //art update properties
        private string selectedArtName;
        public string SelectedArtName
        {
            get { return selectedArtName; }
            set
            {
                if (selectedArtName != value)
                {
                    selectedArtName = value;
                    OnPropertyChanged("SelectedArtName");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }


        public ArtViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            Arts = ReadArts();
        }



        //helps
        private ObservableCollection<Art> ReadArts()
        {
            using (var db = new GDCdbContext())
            {
                return new ObservableCollection<Art>(db.Arts);
            }
        }

        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {

                    var art = new Art
                    {
                        Name = NameText,
                    };

                    db.Arts.Add(art);
                    db.SaveChanges();

                    Arts = new ObservableCollection<Art>(db.Arts);

                }
            }
            
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    db.Arts.Attach(SelectedArt);
                    db.Arts.Remove(SelectedArt);

                    db.SaveChanges();
                    Arts = new ObservableCollection<Art>(db.Arts);
                }
            }
            
        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Arts.SingleOrDefault(b => b.Art_Id == selectedArt.Art_Id);

                    if (result != null)
                    {
                        result.Name = selectedArtName;

                        db.SaveChanges();
                        Arts = new ObservableCollection<Art>(db.Arts);
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
                MessageBox.Show("Art with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateUpdate()
        {
            if (SelectedArt == null)
            {
                MessageBox.Show("Select an art!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedArtName == null || SelectedArtName == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NameExists(SelectedArtName))
            {
                MessageBox.Show("Art with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private bool ValidateDelete()
        {
            if (SelectedArt == null)
            {
                MessageBox.Show("Select an art!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool NameExists(string name)
        {
            using (var db = new GDCdbContext())
            {
                var result = db.Arts.SingleOrDefault(b => b.Name == name);

                if (result == null)
                    return false;

                return true;
            }
        }
    }
}
