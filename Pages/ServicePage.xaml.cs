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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>                      
    public partial class ServicePage : Page
    {
        ServiceManager serviceManager = new ServiceManager();
        public ServicePage()
        {
            InitializeComponent();

            btnServiceInstall.Click += (sender, e) => serviceManager.InstallService();

            btnServiсeStop.Click += (sender, e) => serviceManager.StopService();

            btnServiсeStart.Click += (sender, e) => serviceManager.StartService();

            btnServiceDelete.Click += (sender, e) => serviceManager.DeleteService();
        }
    }
}
