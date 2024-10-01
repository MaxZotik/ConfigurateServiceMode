using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigurateService.Class.FileSettings
{
    public static class FileSetting
    {
        private static string path;
        private static readonly string directory = "Settings";
        private static readonly string mvkSettingsFile = "MVKSettings.xml";
        private static readonly string serviceSettingsFile = "ServiceSettings.xml";

        static FileSetting()
        {
            path = Directory.GetCurrentDirectory();
            FileDirectory.CreateDirectory(path, directory);
        }

        /// <summary>
        /// Метод записи настроек устройств МВК в файл
        /// </summary>
        public static void MVKSettingSave()
        {
            MVKDevice.MVKDevicesList.Sort(new ListSorted());

            string pathFull = @$"{path}\{directory}\{mvkSettingsFile}";

            FileDirectory.DeleteFile(pathFull);

            XmlTextWriter writer = new XmlTextWriter(pathFull, null);

            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;
            writer.WriteStartDocument();
            writer.WriteStartElement("MVKSettings");

            for (int i = 0; i < MVKDevice.MVKDevicesList.Count; i++)
            {
                writer.WriteStartElement($"Device");
                writer.WriteStartElement("IP");
                writer.WriteString(MVKDevice.MVKDevicesList[i].IP);
                writer.WriteEndElement();
                writer.WriteStartElement("Port");
                writer.WriteString(MVKDevice.MVKDevicesList[i].Port);
                writer.WriteEndElement();
                writer.WriteStartElement("Endian");
                writer.WriteString(MVKDevice.MVKDevicesList[i].Endian);
                writer.WriteEndElement();
                writer.WriteStartElement("Crate");
                writer.WriteString(MVKDevice.MVKDevicesList[i].Crate);
                writer.WriteEndElement();
                writer.WriteStartElement("NumberMVK");
                writer.WriteString(MVKDevice.MVKDevicesList[i].NumberMVK);
                writer.WriteEndElement();
                writer.WriteStartElement("Channel");
                writer.WriteString(MVKDevice.MVKDevicesList[i].Channel);
                writer.WriteEndElement();
                writer.WriteStartElement("Frequency");
                writer.WriteString(MVKDevice.MVKDevicesList[i].Frequency);
                writer.WriteEndElement();
                writer.WriteStartElement("Parameter");
                writer.WriteString(MVKDevice.MVKDevicesList[i].Parameter);
                writer.WriteEndElement();
                writer.WriteStartElement("Address");
                writer.WriteString(MVKDevice.MVKDevicesList[i].Address);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
            new FileLogging().WtiteLog("Данные успешно записаны в XML");
        }

        /// <summary>
        /// Метод загрузки настроек устройств МВК из файла
        /// </summary>
        /// <returns>Список устройств МВК</returns>
        public static List<MVKDevice> MVKSettingLoad()
        {
            string pathFull = @$"{path}\{directory}\{mvkSettingsFile}";

            List<MVKDevice> list = new List<MVKDevice>();

            if (File.Exists(pathFull))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(pathFull);
                var root = xmlDocument.DocumentElement;

                if (root != null)
                {
                    foreach (XmlElement elem in root)
                    {
                        list.Add(new MVKDevice(
                        ip: elem.ChildNodes[0].InnerText,
                        port: elem.ChildNodes[1].InnerText,
                        endian: elem.ChildNodes[2].InnerText,
                        crate: elem.ChildNodes[3].InnerText,
                        numberMVK: elem.ChildNodes[4].InnerText,
                        channel: elem.ChildNodes[5].InnerText,
                        frequency: elem.ChildNodes[6].InnerText,
                        parameter: elem.ChildNodes[7].InnerText,
                        address: elem.ChildNodes[8].InnerText));
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Метод записи настроек службы в файл
        /// </summary>
        /// <param name="serviceSetting">Объект настроек службы ServiceSetting</param>
        public static void ServiceSettingSave(ServiceSetting serviceSetting)
        {
            string pathFull = @$"{path}\{directory}\{serviceSettingsFile}";

            FileDirectory.DeleteFile(pathFull);

            XmlTextWriter writer = new XmlTextWriter(pathFull, null);

            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;
            writer.WriteStartDocument();
            writer.WriteStartElement("ServiceSettings");

            writer.WriteStartElement("INTERVAL_ONE");
            writer.WriteString(serviceSetting.IntervalOne);
            writer.WriteEndElement();
            writer.WriteStartElement("INTERVAL_TWO");
            writer.WriteString(serviceSetting.IntervalTwo);
            writer.WriteEndElement();
            writer.WriteStartElement("TIME_GETTING_VALUES");
            writer.WriteString(serviceSetting.TimeGettingValues);
            writer.WriteEndElement();
            writer.WriteStartElement("TIME_GETTING_VALUES_PAUSE");
            writer.WriteString(serviceSetting.TimeGettingValuesPause);
            writer.WriteEndElement();
            writer.WriteStartElement("TIME_GETTING_VALUES_REPEAT");
            writer.WriteString(serviceSetting.TimeGettingValuesRepeat);
            writer.WriteEndElement();
            writer.WriteStartElement("COEFFICIENT_GET_POINT");
            writer.WriteString(serviceSetting.CoefficientGetPoint);
            writer.WriteEndElement();
            writer.WriteStartElement("COEFFICIENT_CHECKS_VERTEX");
            writer.WriteString(serviceSetting.CoefficientChecksVertex);
            writer.WriteEndElement();
            writer.WriteStartElement("COUNT_POINT_INTERVAL");
            writer.WriteString(serviceSetting.CountPointInterval);
            writer.WriteEndElement();
            writer.WriteStartElement("COEFFICIENT_KNOCK");
            writer.WriteString(serviceSetting.CoefficientKnock);
            writer.WriteEndElement();
            writer.WriteStartElement("PORT_SERVER");
            writer.WriteString(serviceSetting.PortServer);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.Close();
            new FileLogging().WtiteLog("Данные успешно записаны в XML");
        }

        /// <summary>
        /// Метод загрузки настроек службы из файла
        /// </summary>
        /// <returns>Объект настроек службы ServiceSetting</returns>
        public static ServiceSetting? ServiceSettingLoad()
        {
            string pathFull = @$"{path}\{directory}\{serviceSettingsFile}";

            if (File.Exists(pathFull))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(pathFull);
                var root = xmlDocument.DocumentElement;

                if (root != null)
                {                    
                    return new ServiceSetting(
                    intervalOne: root.ChildNodes[0].InnerText,
                    intervalTwo: root.ChildNodes[1].InnerText,
                    timeGettingValues: root.ChildNodes[2].InnerText,
                    timeGettingValuesPause: root.ChildNodes[3].InnerText,
                    timeGettingValuesRepeat: root.ChildNodes[4].InnerText,
                    coefficientGetPoint: root.ChildNodes[5].InnerText,
                    coefficientChecksVertex: root.ChildNodes[6].InnerText,
                    countPointInterval: root.ChildNodes[7].InnerText,
                    coefficientKnock: root.ChildNodes[8].InnerText,
                    portServer: root.ChildNodes[9].InnerText);
                }
            }

            return null;

        }

    }
}
