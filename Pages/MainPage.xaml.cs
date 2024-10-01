using ConfigurateService.Class.Navigates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConfigurateService.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            btnSetting.Click += (sender, e) => Navigate.Frame.Navigate(new ConfiguratePage());
            btnStopService.Click += (sender, e) => Navigate.Frame.Navigate(new ServicePage());
            btnServiceSetting.Click += (sender, e) => Navigate.Frame.Navigate(new ServiceSettingPage());


            //btnLogs.Click += (sender, e) =>
            //{
            //    if (!App.Current.Windows.OfType<WindowLog>().Any())
            //    {
            //        WindowLog logs = new WindowLog();
            //        logs.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Окно логов уже запущено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //    }                    
            //};
        }
    }
}
