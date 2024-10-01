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

namespace ConfigurateService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly FileWork fileWork = new FileWork();

        public MainWindow()
        {
            InitializeComponent();

            Navigate.Frame = mainFrame;

            btnBack.Click += (sender, e) => mainFrame.GoBack();
            btnHelper.Click += (sender, e) => fileWork.OpenFileReadmy();
            mainFrame.ContentRendered += (sender, e) => btnBack.Visibility = mainFrame.CanGoBack ? Visibility.Visible : Visibility.Hidden;
            Navigate.Frame.Navigate(new MainPage());
        }
    }
}