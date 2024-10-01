namespace ConfigurateService.Class.Configurate
{
    public class AddressRegister
    {

        public void SetupAddress(ref MVKDevice device)
        {
            switch (device.Frequency)
            {
                case "25Гц":
                    device.Address = device.Parameter == "Пик-Фактор" ? ((int)Register.PickFactor_25Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString() : ((int)Register.VibroAcceleration_25Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                case "10-3000Гц":
                    if (device.Parameter == "Виброускорение")
                        device.Address = ((int)Register.VibroAcceleration_10_3000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else if (device.Parameter == "Виброскорость")
                        device.Address = ((int)Register.VibroSpeed_10_3000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else
                        device.Address = ((int)Register.VibroMoving_10_3000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                case "10-2000Гц":
                    if (device.Parameter == "Виброускорение")
                        device.Address = ((int)Register.VibroAcceleration_10_2000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else if (device.Parameter == "Виброскорость")
                        device.Address = ((int)Register.VibroSpeed_10_2000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else
                        device.Address = ((int)Register.VibroMoving_10_2000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                case "10-1000Гц":
                    if (device.Parameter == "Виброускорение")
                        device.Address = ((int)Register.VibroAcceleration_10_1000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else if (device.Parameter == "Виброскорость")
                        device.Address = ((int)Register.VibroSpeed_10_1000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else
                        device.Address = ((int)Register.VibroMoving_10_1000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                case "2-1000Гц":
                    if (device.Parameter == "Виброускорение")
                        device.Address = ((int)Register.VibroAcceleration_2_1000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else if (device.Parameter == "Виброскорость")
                        device.Address = ((int)Register.VibroSpeed_2_1000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else
                        device.Address = ((int)Register.VibroMoving_2_1000Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                case "0.8-300Гц":
                    if (device.Parameter == "Виброускорение")
                        device.Address = ((int)Register.VibroAcceleration_300Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else if (device.Parameter == "Виброскорость")
                        device.Address = ((int)Register.VibroSpeed_300Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else
                        device.Address = ((int)Register.VibroMoving_300Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                case "0.8-150Гц":
                    if (device.Parameter == "Виброускорение")
                        device.Address = ((int)Register.VibroAcceleration_150Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else if (device.Parameter == "Виброскорость")
                        device.Address = ((int)Register.VibroSpeed_150Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else
                        device.Address = ((int)Register.VibroMoving_150Hz + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                case "Фильтр 1":
                    if (device.Parameter == "Виброускорение")
                        device.Address = ((int)Register.VibroAcceleration_Filter1 + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else if (device.Parameter == "Виброскорость")
                        device.Address = ((int)Register.VibroSpeed_Filter1 + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else
                        device.Address = ((int)Register.VibroMoving_Filter1 + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                case "Фильтр 2":
                    if (device.Parameter == "Виброускорение")
                        device.Address = ((int)Register.VibroAcceleration_Filter2 + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else if (device.Parameter == "Виброскорость")
                        device.Address = ((int)Register.VibroSpeed_Filter2 + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    else
                        device.Address = ((int)Register.VibroMoving_Filter2 + ((512 * (int.Parse(device.Channel) - 1)))).ToString();
                    break;
                default:
                    new FileLogging().WtiteLog("Неизвестная опция в полосе!", LoggingStatus.ERRORS);
                    break;
            }
        }
    }
}
