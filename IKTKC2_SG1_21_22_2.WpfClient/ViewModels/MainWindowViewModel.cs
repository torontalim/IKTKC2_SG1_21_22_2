using IKTKC2_SG1_21_22_2.Models;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IKTKC2_SG1_21_22_2.WpfClient.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public ICommand AddPlayerCommand { get; set; }
        public ICommand UpdatePlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand GetPlayersCommand { get; set; }
        public ICommand PlayerDetailsCommand { get; set; }
        
        private ObservableCollection<Player> players;
        public ObservableCollection<Player> Players {
            get => players;
            set => Set(ref players, value);
        }
        private Player selectedPlayer;
        public Player SelectedPlayer
        {
            get => selectedPlayer;
            set => Set(ref selectedPlayer, value);
        }

        public MainWindowViewModel()
        {
            GetPlayersCommand = new RelayCommand(a => GetPlayers());
            AddPlayerCommand = new RelayCommand(a => OpenPlayerEditorDialog(new Player()));
            UpdatePlayerCommand = new RelayCommand(a => OpenPlayerEditorDialog(selectedPlayer), a => selectedPlayer != null);
            DeletePlayerCommand = new RelayCommand(a => DeletePlayer(), a => selectedPlayer != null);
            PlayerDetailsCommand = new RelayCommand(a => PlayerDetails(), a => selectedPlayer != null);
        }

        private void PlayerDetails()
        {
            if (selectedPlayer != null)
            {
                PlayerEditorWindow playerEditorWindow = new PlayerEditorWindow(selectedPlayer, false, true);
                playerEditorWindow.ShowDialog();
            }
        }

        private void OpenPlayerEditorDialog(Player selectedPlayer)
        {
            PlayerEditorWindow playerEditorWindow = new PlayerEditorWindow(selectedPlayer);
            playerEditorWindow.ShowDialog();

            if (playerEditorWindow.DialogResult.HasValue && playerEditorWindow.DialogResult.Value)
            {
                GetPlayers();
            }
        }

        private void DeletePlayer()
        {
            if (selectedPlayer != null)
            {
                using var client = new HttpClient();
                var result = client.DeleteAsync($"https://localhost:44325/Player/{selectedPlayer.PlayerId}").Result;

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Player is deleted successfully!");
                    GetPlayers();
                }
            }
        }

        private void GetPlayers()
        {
            Players = new ObservableCollection<Player>();

            using var client = new HttpClient();
            var result = client.GetAsync("https://localhost:44325/Player").Result;

            foreach (var player in JsonConvert.DeserializeObject<List<Player>>(result.Content.ReadAsStringAsync().Result))
            {
                Players.Add(player);
            }
        }
    }
}
