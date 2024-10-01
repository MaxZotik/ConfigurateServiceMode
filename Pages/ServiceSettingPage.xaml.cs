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
    /// Логика взаимодействия для ServiceSettingPage.xaml
    /// </summary>
    public partial class ServiceSettingPage : Page
    {
        ServiceSetting? serviceSetting;

        public ServiceSettingPage()
        {
            InitializeComponent();

            serviceSetting = FileSetting.ServiceSettingLoad();

            if (serviceSetting != null)
            {
                tbx_time_getting_values.Text = serviceSetting.TimeGettingValues;
                tbx_time_getting_values_pause.Text = serviceSetting.TimeGettingValuesPause;
                tbx_time_getting_values_repeat.Text = serviceSetting.TimeGettingValuesRepeat;
                tbx_coefficient_get_point.Text = serviceSetting.CoefficientGetPoint;
                tbx_coefficient_checks_vertex.Text = serviceSetting.CoefficientChecksVertex;
                tbx_coefficient_cnock.Text = serviceSetting.CoefficientKnock;
                tbx_number_port_server.Text = serviceSetting.PortServer;
            }

            tbx_time_getting_values.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbx_time_getting_values_pause.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbx_time_getting_values_repeat.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbx_coefficient_get_point.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbx_coefficient_checks_vertex.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbx_coefficient_cnock.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbx_number_port_server.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            btnSave.Click += (sender, e) =>
            {
                if (CheckOnCorrect())
                {
                    ServiceSetting serviceSettingTemp = new ServiceSetting(timeGettingValues: tbx_time_getting_values.Text, 
                        timeGettingValuesPause: tbx_time_getting_values_pause.Text, timeGettingValuesRepeat: tbx_time_getting_values_repeat.Text, 
                        coefficientGetPoint: tbx_coefficient_get_point.Text, coefficientChecksVertex: tbx_coefficient_checks_vertex.Text, 
                        coefficientKnock: tbx_coefficient_cnock.Text, portServer:tbx_number_port_server.Text);

                    FileSetting.ServiceSettingSave(serviceSettingTemp);

                    new FileLogging().WtiteLog("Настройки службы добавленны!", LoggingStatus.NOTIFY);
                    MessageBox.Show("Настройки службы добавленны!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Введенны не корректные данные!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            };
        }


        private bool CheckOnCorrect()
        {
            if (tbx_time_getting_values.Text != null && tbx_time_getting_values_pause.Text != null && tbx_time_getting_values_repeat.Text != null && 
                tbx_coefficient_get_point.Text != null && tbx_coefficient_checks_vertex.Text != null && tbx_coefficient_cnock.Text != null && 
                tbx_number_port_server.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
