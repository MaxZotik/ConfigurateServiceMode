using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurateService.Class.Services
{
    public class ListSorted : IComparer<MVKDevice>
    {
        public int Compare(MVKDevice? x, MVKDevice? y)
        {
            if (x == null || y == null)
                throw new Exception("Невозможно сравнить элементы");

            if (int.Parse(x.Crate) > int.Parse(y.Crate))
            {
                return 1;
            }

            if (int.Parse(x.Crate) < int.Parse(y.Crate))
            {
                return -1;
            }

            if (int.Parse(x.Crate) == int.Parse(y.Crate))
            {
                if (int.Parse(x.NumberMVK) > int.Parse(y.NumberMVK))
                {
                    return 1;
                }

                if (int.Parse(x.NumberMVK) < int.Parse(y.NumberMVK))
                {
                    return -1;
                }
            }

            if (int.Parse(x.Crate) == int.Parse(y.Crate) && int.Parse(x.NumberMVK) == int.Parse(y.NumberMVK))
            {
                if(x.Parameter == "Частота вращения" || y.Parameter == "Частота вращения")
                    return 0;

                if (int.Parse(x.Channel) > int.Parse(y.Channel))
                {
                    return 1;
                }

                if (int.Parse(x.Channel) < int.Parse(y.Channel))
                {
                    return -1;
                }
            }

            return 0;
        }
    }
}
