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
using System.Windows.Shapes;

namespace ConfigurateService.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowLog.xaml
    /// </summary>
    public partial class WindowLog : Window
    {
        FileLogging fileLogging = new FileLogging();
        public WindowLog()
        {
            InitializeComponent();

            InitializeComponent();
            cmbFIlter.ItemsSource = new string[] { "Все", "Только конфигуратор", "Только службу", "Только ошибки", "Только действия" };
            cmbFIlter.SelectedIndex = 0;
            cmbFIlter.SelectionChanged += (sender, e) => lbxLogs.ItemsSource = fileLogging.GetLogs(cmbFIlter.SelectedIndex);
            //cmbFIlter.SelectionChanged += (sender, e) => lbxLogs.ItemsSource = new FileLogging().GetLogs(cmbFIlter.SelectedIndex);
        }
    }
}
