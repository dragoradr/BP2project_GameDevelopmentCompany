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
    public class ArtArtistViewModel : BindableBase
    {
        // combo box values
        public ObservableCollection<string> ArtNames { get; set; }
        public ObservableCollection<string> ArtistNames { get; set; }

        // table list and selected element
        private ObservableCollection<RelModel> artArtists;
        public ObservableCollection<RelModel> ArtArtists
        {
            get { return artArtists; }
            set
            {
                if (value != artArtists)
                {
                    artArtists = value;
                    OnPropertyChanged("ArtArtists");
                }
            }
        }

        private RelModel selectedArtArtist = null;
        public RelModel SelectedArtArtist
        {
            get { return selectedArtArtist; }
            set
            {
                if (selectedArtArtist != value)
                {
                    selectedArtArtist = value;
                    OnPropertyChanged("SelectedArtArtist");

                    SelectedArtArtistArtist = selectedArtArtist.Name2;
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

        private string selectedArtist;
        public string SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (selectedArtist != value)
                {
                    selectedArtist = value;
                    OnPropertyChanged("SelectedArtist");
                }
            }
        }


        // combo box update
        private string selectedArtArtistArtist;
        public string SelectedArtArtistArtist
        {
            get { return selectedArtArtistArtist; }
            set
            {
                if (selectedArtArtistArtist != value)
                {
                    selectedArtArtistArtist = value;
                    OnPropertyChanged("SelectedArtArtistArtist");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public ArtArtistViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            ArtArtists = ReadArtArtists();
            ArtNames = ReadArtNames();
            ArtistNames = ReadArtistNames();
        }


        // command methods
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var art = db.Arts.SingleOrDefault(b => b.Name == SelectedArt);
                    var artist = db.Employees.SingleOrDefault(b => b.First_name == SelectedArtist);

                    art.Artists.Add((Artist)artist);

                    db.SaveChanges();

                    ArtArtists = ReadArtArtists();
                }
            }
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Arts.SingleOrDefault(b => b.Name == selectedArtArtist.Name1);
                    result.Artists.Clear();

                    db.SaveChanges();
                    ArtArtists = ReadArtArtists();
                }
            }
            
        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var art = db.Arts.SingleOrDefault(b => b.Name == selectedArtArtist.Name1);
                    var artist = db.Employees.SingleOrDefault(b => b.First_name == selectedArtArtistArtist);

                    art.Artists.Clear();
                    art.Artists.Add((Artist)artist);

                    db.SaveChanges();
                    ArtArtists = ReadArtArtists();
                }
            }
            
        }


        // read stuff
        private ObservableCollection<RelModel> ReadArtArtists()
        {
            ObservableCollection<RelModel> arts = new ObservableCollection<RelModel>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Arts)
                {
                    if (item.Artists.Count > 0)
                        arts.Add(new RelModel { Name1 = item.Name, Name2 = item.Artists.ToList()[0].First_name });
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
                    if (item.Artists.Count == 0)
                        arts.Add(item.Name);
                }

                return arts;
            }
        }

        private ObservableCollection<string> ReadArtistNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Employees)
                {
                    if (item is Artist)
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
            else if (SelectedArtist == null)
            {
                MessageBox.Show("Select an artist!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private bool ValidateUpdate()
        {
            if (SelectedArtArtist == null)
            {
                MessageBox.Show("Select an item", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else if (SelectedArtArtistArtist == null)
            {
                MessageBox.Show("Select an artist!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedArtArtist == null)
            {
                MessageBox.Show("Select an item!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
