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
    public class GameBetaVersionViewModel : BindableBase
    {
        // combo box values
        public ObservableCollection<string> GameNames { get; set; }
        public ObservableCollection<string> BetaNames { get; set; }

        // table list and selected element
        private ObservableCollection<RelModel> gameBetas;
        public ObservableCollection<RelModel> GameBetas
        {
            get { return gameBetas; }
            set
            {
                if (value != gameBetas)
                {
                    gameBetas = value;
                    OnPropertyChanged("GameBetas");
                }
            }
        }

        private RelModel selectedGameBeta = null;
        public RelModel SelectedGameBeta
        {
            get { return selectedGameBeta; }
            set
            {
                if (selectedGameBeta != value)
                {
                    selectedGameBeta = value;
                    OnPropertyChanged("SelectedGameBeta");

                    SelectedGameBetaBeta = selectedGameBeta.Name2;
                }
            }
        }

        // combo box picked 
        private string selectedGame;
        public string SelectedGame
        {
            get { return selectedGame; }
            set
            {
                if (selectedGame != value)
                {
                    selectedGame = value;
                    OnPropertyChanged("SelectedGame");
                }
            }
        }

        private string selectedBeta;
        public string SelectedBeta
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


        // combo box update
        private string selectedGameBetaBeta;
        public string SelectedGameBetaBeta
        {
            get { return selectedGameBetaBeta; }
            set
            {
                if (selectedGameBetaBeta != value)
                {
                    selectedGameBetaBeta = value;
                    OnPropertyChanged("SelectedGameBetaBeta");
                }
            }
        }

        // commands
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public GameBetaVersionViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            UpdateCommand = new MyICommand(OnUpdate);

            GameBetas = ReadGameBetas();
            GameNames = ReadGameNames();
            BetaNames = ReadBetaNames();
        }


        // command methods
        private void OnAdd()
        {
            if (ValidateAdd())
            {
                using (var db = new GDCdbContext())
                {
                    var game = db.Games.SingleOrDefault(b => b.Name == SelectedGame);
                    var beta = db.BetaVersions.SingleOrDefault(b => b.Name == SelectedBeta);

                    game.BetaVersions.Add(beta);

                    db.SaveChanges();

                    GameBetas = ReadGameBetas();
                }
            }
           
        }
    
        private void OnDelete()
        {
            if (ValidateDelete())
            {
                using (var db = new GDCdbContext())
                {
                    var result = db.Games.SingleOrDefault(b => b.Name == selectedGameBeta.Name1);
                    result.BetaVersions.Clear();

                    db.SaveChanges();
                    GameBetas = ReadGameBetas();
                }
            }
        }

        private void OnUpdate()
        {
            if (ValidateUpdate())
            {
                using (var db = new GDCdbContext())
                {
                    var game = db.Games.SingleOrDefault(b => b.Name == selectedGameBeta.Name1);
                    var beta = db.BetaVersions.SingleOrDefault(b => b.Name == selectedGameBetaBeta);

                    game.BetaVersions.Clear();
                    game.BetaVersions.Add(beta);

                    db.SaveChanges();
                    GameBetas = ReadGameBetas();
                }
            }        
        }


        // read stuff
        private ObservableCollection<RelModel> ReadGameBetas()
        {
            ObservableCollection<RelModel> games = new ObservableCollection<RelModel>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Games)
                {
                    if (item.BetaVersions.Count > 0)
                        games.Add(new RelModel { Name1 = item.Name, Name2 = item.BetaVersions.ToList()[0].Name });
                }

                return games;
            }
        }

        private ObservableCollection<string> ReadGameNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.Games)
                {
                    if (item.BetaVersions.Count == 0)
                        names.Add(item.Name);
                }

                return names;
            }
        }
 
        private ObservableCollection<string> ReadBetaNames()
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            using (var db = new GDCdbContext())
            {
                foreach (var item in db.BetaVersions)
                {
                    if (item.Games.Count == 0)
                        names.Add(item.Name);
                }

                return names;
            }
        }


        //validation
        private bool ValidateAdd()
        {

            if (SelectedGame == null)
            {
                MessageBox.Show("Select a game!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (SelectedBeta == null)
            {
                MessageBox.Show("Select a beta!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateUpdate()
        {
            if (SelectedGameBeta == null)
            {
                MessageBox.Show("Select an item", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            else if (SelectedGameBetaBeta == null)
            {
                MessageBox.Show("Select a beta!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool ValidateDelete()
        {
            if (SelectedGameBetaBeta == null)
            {
                MessageBox.Show("Select an item!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
