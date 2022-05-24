using IKTKC2_SG1_21_22_2.Models;
using IKTKC2_SG1_21_22_2.Models.Dto;
using IKTKC2_SG1_21_22_2.WpfClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IKTKC2_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for PlayerEditorWindow.xaml
    /// </summary>
    public partial class PlayerEditorWindow : Window
    {
        public PlayerEditorWindowViewModel VM { get; set; }

        public PlayerEditorWindow(Player player, bool isEnabled = true, bool isReadOnly = false)
        {
            InitializeComponent();
            VM = new PlayerEditorWindowViewModel();

            VM.PlayerDto = new PlayerDto
            {
                Name = player.Name,
                Email = player.Email,
                DateOfBirth = player.DateOfBirth,
                Active = player.Active,
                PhoneNumber = player.PhoneNumber
            };
            VM.PlayerId = player.PlayerId;
            VM.IsEnabled = isEnabled;
            VM.IsReadOnly = isReadOnly;

            if (isEnabled == false)
            {
                SaveButton.Visibility = Visibility.Hidden;
            }

            DataContext = VM;
        }

        private void CheckResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                DialogResult = true;
            }
            
            MessageBox.Show(response.Content.ReadAsStringAsync().Result);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            HttpResponseMessage response;
 
            if (VM.PlayerId > 0)
            {
                response = VM.UpdatePlayer();
            }
            else
            {
                response = VM.AddPlayer();
            }

            CheckResponse(response);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
