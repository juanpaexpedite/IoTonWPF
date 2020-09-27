using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTonWPF.Managers
{
    public class ProcessDataManager
    {
        public static void SetData(object instance, string property, string value)
        {
            var info = instance.GetType().GetProperty(property);
            info.SetValue(instance, value);
        }
    }
}
