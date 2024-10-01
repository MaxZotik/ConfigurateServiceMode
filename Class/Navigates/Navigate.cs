using System.Windows.Controls;

namespace ConfigurateService.Class.Navigates
{
    public class Navigate
    {
        public static Frame Frame { get; set; }
        
        static Navigate()
        {
            Frame = new Frame();
        }
    }
}
