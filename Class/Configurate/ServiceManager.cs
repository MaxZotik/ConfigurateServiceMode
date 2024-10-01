using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurateService.Class.Configurate
{
    public class ServiceManager
    {
        /// <summary>
        /// Метод устанавливает службу
        /// </summary>
        public void InstallService()
        {
            Cmd("cmd.exe", $@"cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319 & InstallUtil.exe ""{Directory.GetCurrentDirectory()}\ModeDetectionService.exe""");
            //Cmd("cmd.exe", $@"cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319 & InstallUtil.exe ""C:\zotikov\CodeApp\ModeDetectionService\ModeDetectionService\bin\Debug\ModeDetectionService.exe""");
        }

        /// <summary>
        /// Метод останавливает службу
        /// </summary>
        public void StopService()
        {
            Cmd("cmd", "sc stop ModeDetectionService");
            Cmd("cmd", "taskkill /IM ModeDetectionService.exe /F");
        }

        /// <summary>
        /// Метод запускает службу
        /// </summary>
        public void StartService()
        {
            Cmd("cmd", "sc start ModeDetectionService");
        }

        /// <summary>
        /// Метод удаления службы
        /// </summary>
        public void DeleteService()
        {
            Cmd("cmd.exe", $@"cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319 & InstallUtil.exe /u ""{Directory.GetCurrentDirectory()}\ModeDetectionService.exe""");
            //Cmd("cmd.exe", $@"cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319 & InstallUtil.exe /u ""C:\zotikov\CodeApp\ModeDetectionService\ModeDetectionService\bin\Debug\ModeDetectionService.exe""");
        }

        /// <summary>
        /// Метод для запуска командной строки
        /// </summary>
        /// <param name="fileName">Название файла для запуска</param>
        /// <param name="cmd">Команда для командной строки</param>
        private void Cmd(string fileName, string cmd)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = $"{fileName}",
                Arguments = $@"/c {cmd}",
                CreateNoWindow = false,
                //WindowStyle = ProcessWindowStyle.Hidden,
                WindowStyle = ProcessWindowStyle.Normal,
                UseShellExecute = true
            });
        }
    }
}
