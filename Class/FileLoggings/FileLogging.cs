using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurateService.Class.FileLoggings
{
    public class FileLogging
    {
        private static string path;
        private static readonly string directory = "Loggings";
        private static readonly string nameFileConfig = "LogConfigurateService.log";
        private static readonly string nameFileService = "LogModeDetectionService.log";

        static FileLogging()
        {
            path = Directory.GetCurrentDirectory();
            FileDirectory.CreateDirectory(path, directory);
            FileDirectory.CreateFile(path, directory, nameFileConfig);
            FileDirectory.CreateFile(path, directory, nameFileService);
        }

        /// <summary>
        /// Метод записывает логи приложения в файл
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="status">Статус сообщения</param>
        public void WtiteLog(in string message, LoggingStatus status = LoggingStatus.NOTIFY)
        {
            string pathTemp = @$"{path}\{directory}\{nameFileConfig}";

            using (StreamWriter writer = new StreamWriter(pathTemp, true))
            {
                writer.WriteLine($"|{status}| {DateTime.Now} {message}{Environment.NewLine}");
            }               
        }

        public string[] GetLogs(in int index)
        {
            List<string> logs = new List<string>();
            string pathConfig = $@"{path}\{directory}\{nameFileConfig}";
            string pathService = $@"{path}\{directory}\{nameFileService}";
            string pathDirect = $@"{path}\{directory}";

            if ((!File.Exists(pathConfig) || !File.Exists(pathService)) && !Directory.Exists(pathDirect))
            {
                logs.Add($"|{LoggingStatus.ERRORS}| {DateTime.Now} НЕТ ЛОГОВ");
                return logs.ToArray();
            }

            try
            {
                if (index == 1)
                    return File.ReadLines(pathConfig).Where(x => x.StartsWith("|")).ToArray();
                else if (index == 2)
                    return File.ReadLines(pathService).Where(x => x.StartsWith("|")).ToArray();
                else if (index == 3)
                {
                    logs.AddRange(File.ReadLines(pathConfig).Where(x => x.StartsWith("|ERRORS|")).ToArray());
                    logs.AddRange(File.ReadLines(pathService).Where(x => x.StartsWith("|ERRORS|")).ToArray());
                    return logs.ToArray();
                }
                else if (index == 4)
                {
                    logs.AddRange(File.ReadLines(pathConfig).Where(x => x.StartsWith("|ACTION|")).ToArray());
                    logs.AddRange(File.ReadLines(pathService).Where(x => x.StartsWith("|ACTION|")).ToArray());
                    return logs.ToArray();
                }
                else
                {
                    logs.AddRange(File.ReadLines(pathConfig).Where(x => x.StartsWith("|")).ToArray());
                    logs.AddRange(File.ReadLines(pathService).Where(x => x.StartsWith("|")).ToArray());
                    return logs.ToArray();
                }
            }
            catch
            {
                logs.Add($"|{LoggingStatus.ERRORS}| {DateTime.Now} НЕТ ЛОГОВ");
                return logs.ToArray();
            }
        }
    }
}
