using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurateService.Class.Configurate
{
    internal class AddressRegisterSpeed
    {
        public void SetupAddressSpeed(ref MVKDevice device)
        {
            switch (device.Frequency)
            {
                case "Частота вращения":
                    if (device.Parameter == "Частота вращения")
                        device.Address = ((int)RegisterSpeed.RotationSpeed + ((256 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                default:
                    new FileLogging().WtiteLog("Неизвестная опция в полосе!", LoggingStatus.ERRORS);
                    break;
            }
        }
    }
}
