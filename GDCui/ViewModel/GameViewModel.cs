using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Database;
using GDCui.Helpers;

namespace GDCui.ViewModel
{
    public class GameViewModel : BindableBase
    {
        public ObservableCollection<string> CompanyNames { get; set; }

        private ObservableCollection<Game> games { get; set; }
        public ObservableCollection<Game> Games
        {
            get { return games; }
            set
            {
                if (games != value)
                {
                    games = value;
                    OnPropertyChanged("Games");
                }
            }
        }

        private Game selectedGame = new Game();
        public Game SelectedGame
        {
            get { return selectedGame; }
            set
            {
                if (selectedGame != value)
                {
                    selectedGame = value;
                    OnPropertyChanged("SelectedGame");

                    SelectedGameName = selectedGame.Name;
                    SelectedGameGenre = selectedGame.Genre;
                    selectedGameRelease = selectedGame.Release_date;
                    SelectedGameCompany = GetCompanyName(selectedGame.GameDevelopmentCompanyCompany_Id);
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

        //game properties
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

        private string genreText;
        public string GenreText
        {
            get { return genreText; }
            set
            {
                if (genreText != value)
                {
                    genreText = value;
                    OnPropertyChanged("GenreText");
                }
            }
        }

        private string releaseText;
        public string ReleaseText
        {
            get { return releaseText; }
            set
            {
                if (releaseText != value)
                {
                    releaseText = value;
                    OnPropertyChanged("ReleaseText");
                }
            }
        }


        //game update properties
        private string selectedGameName;
        public string SelectedGameName
        {
            get { return selectedGameName; }
            set
            {
                if (selectedGameName != value)
                {
                    selectedGameName = value;
                    OnPropertyChanged("SelectedGameName");
                }
            }
        }

        private string selectedGameGenre;
        public string SelectedGameGenre
        {
            get { return selectedGameGenre; }
            set
            {
                if (selectedGameGenre != value)
                {
                    selectedGameGenre = value;
                    OnPropertyChanged("SelectedGameGenre");
                }
            }
        }

        private string selectedGameRelease;
        public string SelectedGameRelease
        {
            get { return selectedGameRelease; }
            set
            {
                if (selectedGameRelease != value)
                {
                    selectedGameRelease = value;
                    OnPropertyChanged("SelectedGameRelease");
                }
            }
        }

        private string selectedGameCompany;
        public string SelectedGameCompany
        {
            get { return selectedGameCompany; }
            set
            {
                if (selectedGameCompany != value)
                {
                    selectedGameCompany = value;
                    OnPropertyChanged("SelectedGameCompany");
                }
            }
        }

        //commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }
        public GameViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);
            Games = ReadGames();
            CompanyNames = ReadCompanies();
        }




        //helps
        private ObservableCollection<Game> ReadGames()
        {
            using (var db = new GDCdbContext())
            {
                return new ObservableCollection<Game>(db.Games);
            }
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

        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var game = new Game
                    {
                        Name = NameText,
                        Genre = GenreText,
                        Release_date = releaseText,
                        GameDevelopmentCompanyCompany_Id = GetCompanyId(selectedCompany)

                    };

                    db.Games.Add(game);
                    db.SaveChanges();

                    Games = new ObservableCollection<Game>(db.Games);
                }


            }
        }

        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    db.Games.Attach(SelectedGame);
                    db.Games.Remove(SelectedGame);

                    db.SaveChanges();
                    Games = new ObservableCollection<Game>(db.Games);
                }
            }

        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Games.SingleOrDefault(b => b.Game_Id == selectedGame.Game_Id);

                    if (result != null)
                    {
                        result.Name = selectedGameName;
                        result.Genre = selectedGameGenre;
                        result.Release_date = selectedGameRelease;
                        db.SaveChanges();
                        Games = new ObservableCollection<Game>(db.Games);
                    }
                }
            }
            
        }

        private ObservableCollection<BetaVersion> ReadBetas()
        {
            using (var db = new GDCdbContext())
            {
                return new ObservableCollection<BetaVersion>(db.BetaVersions);
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
                MessageBox.Show("Game with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (GenreText == null || GenreText == "")
            {
                MessageBox.Show("Enter a genre!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (ReleaseText == null || ReleaseText == "")
            {
                MessageBox.Show("Enter a release date!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedCompany == null)
            {
                MessageBox.Show("Select a company!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private bool ValidateUpdate()
        {
            if (SelectedGame == null)
            {
                MessageBox.Show("Select a game!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (NameExists(NameText))
            {
                MessageBox.Show("Game with that name already exists!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedGameName == null || SelectedGameName == "")
            {
                MessageBox.Show("Enter a name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedGameGenre == null || SelectedGameGenre == "")
            {
                MessageBox.Show("Enter a genre!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedGameRelease == null || SelectedGameRelease == "")
            {
                MessageBox.Show("Enter a release date!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedCompany == null)
            {
                MessageBox.Show("Select a company!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedGame == null)
            {
                MessageBox.Show("Select a game!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
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
