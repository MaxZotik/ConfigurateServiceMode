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
    /// Логика взаимодействия для ConfiguratePage.xaml
    /// </summary>
    public partial class ConfiguratePage : Page
    {
        public ConfiguratePage()
        {
            InitializeComponent();

            Rendering();

            btnRemove.IsEnabled = false;
            btnEdit.IsEnabled = false;

            lbxDevice.SelectionChanged += (sender, e) =>
            {
                btnRemove.IsEnabled = true;
                btnEdit.IsEnabled = true;

                if (MVKDevice.MVKDevicesList.Count == 0)
                {
                    btnRemove.IsEnabled = false;
                    btnEdit.IsEnabled = false;
                }
            };

            btnRemove.Click += (sender, e) =>
            {
                if (lbxDevice.SelectedIndex != -1 && lbxDevice.Items[0].ToString() != "НЕТ ПАРАМЕТРОВ")
                {
                    MVKDevice.MVKDevicesList.RemoveAt(lbxDevice.SelectedIndex);
                    FileSetting.MVKSettingSave();
                    Rendering();
                    MessageBox.Show("МВК устройство удалено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    MessageBox.Show("Необходимо выбрать элемент!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            };

            btnAdd.Click += (sender, e) => { Navigate.Frame.Navigate(new AddPage()); };

            btnEdit.Click += (sender, e) => {
                StorageValuePage.Index = lbxDevice.SelectedIndex;
                Navigate.Frame.Navigate(new EditPage()); 
            };

            Navigate.Frame.ContentRendered += (sender, e) => { 
                Rendering();
                btnRemove.IsEnabled = false;
                btnEdit.IsEnabled = false;
            };
        }

        private void Rendering()
        {
            lbxDevice.ItemsSource = GetPrintDevice();
        }

        private List<string> GetPrintDevice()
        {
            List<string> deviceList = new List<string>();

            MVKDevice.MVKDevicesList.Sort(new ListSorted());

            if (MVKDevice.MVKDevicesList.Count > 0)
            {
                foreach (var device in MVKDevice.MVKDevicesList)
                {
                    deviceList.Add(
                        $"IP адрес: { device.IP } { Environment.NewLine }" +
                        $"Port: {device.Port} {Environment.NewLine}" +
                        $"Порядок передачи байт: {device.Endian} {Environment.NewLine}" +
                        $"Номер клети: {device.Crate} {Environment.NewLine}" +
                        $"Номер МВК: {device.NumberMVK} {Environment.NewLine}" +
                        $"Канал: {device.Channel} {Environment.NewLine}" +
                        $"Полоса частот: {device.Frequency} {Environment.NewLine}" +
                        $"Параметр: {device.Parameter} {Environment.NewLine}" +
                        $"Адрес: {device.Address} {Environment.NewLine}");
                }
            }
            else
            {
                deviceList.Add("НЕТ ПАРАМЕТРОВ");
            }

            return deviceList;
        }
    }
}
