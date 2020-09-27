using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Models
{
    public class TemperatureSensor : BindableBase
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private double value;
        public double Value
        {
            get { return value; }
            set { SetProperty(ref value, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private DateTime timestamp;
        public DateTime TimeStamp
        {
            get { return timestamp; }
            set { SetProperty(ref timestamp, value); }
        }
    }
}
