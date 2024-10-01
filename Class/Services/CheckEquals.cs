using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurateService.Class.Services
{
    public class CheckEquals
    {
        /// <summary>
        /// Метод проверяет новое МВК устройство на наличие в списке
        /// </summary>
        /// <param name="mvkDevice">Новое МВК устройство</param>
        /// <returns>True - МВК устройство есть в списке. False - МВК устройства нет в списке</returns>
        public static bool CheckEqualsDevice(MVKDevice mvkDevice)
        {

            foreach(MVKDevice mvk in MVKDevice.MVKDevicesList)
            {
                if(mvk.Equals(mvkDevice))
                    return true;
            }

            return false;
        }
    }
}
