using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConfigurateService.Class.FileWork
{
    public class FileWork
    {
        /// <summary>
        /// Метод открывает файл описания службы
        /// </summary>
        public void OpenFileReadmy()
        {
            string path = @$"{Directory.GetCurrentDirectory()}\Resources\Guides\Readme.docx";

            if (File.Exists(path))
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = "cmd",
                    Arguments = @$"/c {path}",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Отсутствует файл Readme!", "Уведомление!", MessageBoxButton.OK);
            }            
        }
    }
}
