using IKTKC2_SG1_21_22_2.WpfClient.ViewModels;
using System.Windows;

namespace IKTKC2_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel VM;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VM = (MainWindowViewModel)FindResource("VM");
            VM.GetPlayersCommand.Execute(null);
        }
    }
}
