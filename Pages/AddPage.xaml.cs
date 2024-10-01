using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
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

            tbxIP.PreviewTextInput += (sender, e) =>
            {
                for (int i = 0; i < tbxIP.Text.Length; i++)
                {
                    if (i == 3 || i == 7 || i == 9)
                        if (char.IsPunctuation(tbxIP.Text, i))
                            e.Handled = false;
                        else
                            e.Handled = true;
                    else
                        if (char.IsDigit(tbxIP.Text, i))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
            };

            tbxPort.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbxCrate.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbxNumber.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            tbxChannel.PreviewTextInput += (sender, e) =>
            {
                if (!char.IsDigit(e.Text, 0))
                    e.Handled = true;
            };

            btnPing.Click += (sender, e) =>
            {
                if (IPAddress.TryParse(tbxIP.Text, out IPAddress address) == true)
                {
                    if (Process.GetProcessesByName("cmd").Length < 1)
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = "cmd",
                            Arguments = $"/c ping {address} -t",
                        });
                    }
                    else
                    {
                        MessageBox.Show("Пинг уже запущен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }                        
                }
                else
                {
                    MessageBox.Show("Необходимо заполнить поле IP адрес!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }                   
            };

            btnSave.Click += (sender, e) =>
            {
                if (CheckOnCorrect())
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


                    if (CheckEquals.CheckEqualsDevice(mvkDevice))
                    {
                        MessageBox.Show("Такое МВК утсройство уже сконфигурировано! Измените конфигурацию МВК устройства!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else 
                    {
                        MVKDevice.MVKDevicesList.Add(mvkDevice);

                        new FileLogging().WtiteLog("МВК утсройство добавленно!", LoggingStatus.NOTIFY);
                        MessageBox.Show("МВК утсройство добавленно!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);

                        FileSetting.MVKSettingSave();
                    }                  
                }
                else
                {
                    MessageBox.Show("Введенны не корректные данные!", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Warning);
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
    }
}
