using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfHobbyList.ViewModels;

namespace WpfHobbyList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HobbyViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new HobbyViewModel();
            DataContext = viewModel;
            Loaded += HobbiesView_Loaded;
        }

        private async void HobbiesView_Loaded(object sender, RoutedEventArgs e)
        {
            await viewModel.LoadAsync();
        }

        private void AddHobby(object sender, RoutedEventArgs e)
        {
            btnAddHobby.Content = "Hobby tillagd";
            btnAddHobby.IsEnabled = false;
        }
    }
}