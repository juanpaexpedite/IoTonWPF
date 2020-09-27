using IoTonWPF.Managers;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTonWPF.ViewModels
{
    public class ProcessedViewModel : BindableBase
    {
        public static ProcessedViewModel Instance;
        public ProcessedViewModel()
        {
            Instance = this;
        }

        internal void ReceiveData(string data)
        {
            UpdateData(data);
        }

        #region Temperature
        private string temperaturearea0;
        public string TemperatureArea0
        {
            get { return temperaturearea0; }
            set { SetProperty(ref temperaturearea0, value); }
        }

        /// <summary>
        /// Sensor Area Value Units
        /// </summary>
        /// <param name="rawdata"></param>
        public void UpdateData(string rawdata)
        {
            var data = rawdata.Split(' ');
            
            if (data.Length == 4)
            {
                var property = $"{data[0]}{data[1]}";
                ProcessDataManager.SetData(this, property, $"{data[2]} {data[3]}");
            }
        }
        #endregion


    }
}
