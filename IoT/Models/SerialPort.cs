using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Models
{
    public class SerialPort : BindableBase
    {
        public SerialPort() { }

        public SerialPort((string name, string description) info)
        {
            this.name = info.name;
            this.description = info.description;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
