using IKTKC2_SG1_21_22_2.Models;
using IKTKC2_SG1_21_22_2.Models.Dto;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace IKTKC2_SG1_21_22_2.WpfClient.ViewModels
{
    public class PlayerEditorWindowViewModel : ObservableObject, INotifyPropertyChanged
    {
        private PlayerDto playerDto;
        public PlayerDto PlayerDto
        {
            get => playerDto;
            set
            {
                Set(ref playerDto, value);
                RaisePropertyChanged("PlayerDto");
            }
        }

        private bool isEnabled;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            { 
                Set(ref isEnabled, value);
                RaisePropertyChanged("IsEnabled");
                RaisePropertyChanged("IsReadOnly");
            }
        }

        private bool isReadOnly;
        public bool IsReadOnly
        {
            get => isReadOnly;
            set
            {
                Set(ref isReadOnly, value);
                RaisePropertyChanged("IsReadOnly");
            }
        }

        public int PlayerId { get; set; }

        public HttpResponseMessage AddPlayer()
        {
            using var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(PlayerDto), Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44325/Player", content).Result;

            return result;
        } 

        public HttpResponseMessage UpdatePlayer()
        {
            using var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(PlayerDto), Encoding.UTF8, "application/json");
            var result = client.PutAsync($"https://localhost:44325/Player/{PlayerId}", content).Result;

            return result;
        }
    }
}
