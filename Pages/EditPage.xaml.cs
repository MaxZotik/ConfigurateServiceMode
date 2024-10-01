using ConfigurateService.Class.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        
        public EditPage()
        {
            InitializeComponent();

            cmbFrequency.ItemsSource = DictionaryArray.FrequencyArray;
            cmbEndians.ItemsSource = DictionaryArray.EndianArray;

            cmbFrequency.SelectionChanged += (sender, e) =>
            {
                if (cmbFrequency.SelectedIndex == 0)
                {
                    cmbParameter.ItemsSource = null;
                    cmbParameter.ItemsSource = DictionaryArray.ParameterOneArray;
                }
                else if (cmbFrequency.SelectedIndex == 1)
                {
                    cmbParameter.ItemsSource = null;
                    cmbParameter.ItemsSource = DictionaryArray.RotationSpeedArray;
                }
                else
                {
                    cmbParameter.ItemsSource = null;
                    cmbParameter.ItemsSource = DictionaryArray.ParameterTwoArray;
                }
            };


            tbxIP.Text = MVKDevice.MVKDevicesList[StorageValuePage.Index].IP;
            tbxPort.Text = MVKDevice.MVKDevicesList[StorageValuePage.Index].Port;
            tbxCrate.Text = MVKDevice.MVKDevicesList[StorageValuePage.Index].Crate;
            tbxNumber.Text = MVKDevice.MVKDevicesList[StorageValuePage.Index].NumberMVK;
            tbxChannel.Text = MVKDevice.MVKDevicesList[StorageValuePage.Index].Channel;
            cmbFrequency.SelectedValue = MVKDevice.MVKDevicesList[StorageValuePage.Index].Frequency;
            cmbParameter.SelectedValue = MVKDevice.MVKDevicesList[StorageValuePage.Index].Parameter;
            cmbEndians.SelectedValue = MVKDevice.MVKDevicesList[StorageValuePage.Index].Endian;

            btnSave.Click += (sender, e) =>
            {
                if (CheckOnCorrect() && CheckOnEdit())
                {
                    MVKDevice mvkDevice = new MVKDevice(tbxIP.Text, tbxPort.Text, cmbEndians.SelectedValue.ToString(),
                        tbxCrate.Text, tbxNumber.Text, tbxChannel.Text, cmbFrequency.SelectedValue.ToString(), cmbParameter.SelectedValue.ToString(), "");

                    if (cmbFrequency.SelectedIndex == 1 && cmbParameter.SelectedIndex == 0)
                    {
                        new AddressRegisterSpeed().SetupAddressSpeed(ref mvkDevice);
                    }
                    else
                    {
                        new AddressRegister().SetupAddress(ref mvkDevice);
                    }

                    MVKDevice.MVKDevicesList[StorageValuePage.Index] = mvkDevice;

                    new FileLogging().WtiteLog("МВК утсройство изменено!", LoggingStatus.NOTIFY);
                    
                    FileSetting.MVKSettingSave();

                    MessageBox.Show("МВК утсройство изменено!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            };
        }

        /// <summary>
        /// Метод проверяет правильность заполнения полей
        /// </summary>
        /// <returns>Возвращает (true / false)</returns>
        private bool CheckOnCorrect()
        {
            if (tbxIP.Text != null && tbxPort.Text != null && cmbEndians.SelectedIndex != -1 && cmbFrequency.SelectedIndex != -1 && cmbParameter.SelectedIndex != -1 && tbxChannel.Text != null &&
                tbxNumber.Text != null && tbxCrate.Text != null && IPAddress.TryParse(tbxIP.Text, out IPAddress address) == true)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Метод проверяет было ли внесенно изменение в поля
        /// </summary>
        /// <returns>Возвращает (true / false)</returns>
        private bool CheckOnEdit()
        {
            if (tbxIP.Text != MVKDevice.MVKDevicesList[StorageValuePage.Index].IP ||
                tbxPort.Text != MVKDevice.MVKDevicesList[StorageValuePage.Index].Port ||                
                tbxCrate.Text != MVKDevice.MVKDevicesList[StorageValuePage.Index].Crate ||
                tbxNumber.Text != MVKDevice.MVKDevicesList[StorageValuePage.Index].NumberMVK ||
                tbxChannel.Text != MVKDevice.MVKDevicesList[StorageValuePage.Index].Channel ||
                cmbFrequency.SelectedValue.ToString() != MVKDevice.MVKDevicesList[StorageValuePage.Index].Frequency ||
                cmbParameter.SelectedValue.ToString() != MVKDevice.MVKDevicesList[StorageValuePage.Index].Parameter ||
                cmbEndians.SelectedValue.ToString() != MVKDevice.MVKDevicesList[StorageValuePage.Index].Endian)
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
