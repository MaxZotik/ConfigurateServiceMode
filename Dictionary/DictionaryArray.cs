using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurateService.Dictionary
{
    public static class DictionaryArray
    {
        public static string[] FrequencyArray { get;  set; }

        public static string[] ParameterOneArray { get; set; }

        public static string[] ParameterTwoArray { get; set; }

        public static string[] EndianArray { get; set; }

        public static string[] RotationSpeedArray { get; set; }

        static DictionaryArray()
        {
            FrequencyArray = new string[] { "25Гц", "Частота вращения", "10-3000Гц", "10-2000Гц", "10-1000Гц", "2-1000Гц", "0.8-300Гц", "0.8-150Гц", "Фильтр 1", "Фильтр 2" };
            ParameterOneArray = new string[] { "Пик-Фактор", "Виброускорение" };
            ParameterTwoArray = new string[] { "Виброускорение", "Виброскорость", "Виброперемещение" };
            EndianArray = new string[] { "2301", "0123", "3210" };
            RotationSpeedArray = new string[] { "Частота вращения" };
        }
    }
}
