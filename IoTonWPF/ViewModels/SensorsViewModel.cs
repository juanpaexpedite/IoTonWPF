using IoT;
using IoT.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTonWPF.ViewModels
{
    public class SensorsViewModel : BindableBase
    {
        public SensorsViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            cp2102 = new CP2102Manager();
            ExecuteRefreshPorts();
        }


        #region CP2102
        CP2102Manager cp2102 = null;

        private DelegateCommand startreading;
        public DelegateCommand StartReading => startreading ?? (startreading = new DelegateCommand(ExecuteStartReading));

        void ExecuteStartReading()
        {
            if (currentcomport != null)
            {
                cp2102.Start(currentcomport.Name, ReadData);
                CaptureDataLabel = "READING...";
            }
            else
            {
                CaptureDataLabel = "CHOOSE COM";
            }
        }

        private DelegateCommand stopreading;
        public DelegateCommand StopReading => stopreading ?? (stopreading = new DelegateCommand(ExecuteStopReading));

        void ExecuteStopReading()
        {
            cp2102.Stop();
            CaptureDataLabel = "CAPTURE DATA";
        }
        #endregion

        #region Serial Ports
        private SerialPort currentcomport;
        public SerialPort CurrentComPort
        {
            get { return currentcomport; }
            set { SetProperty(ref currentcomport, value); }
        }

        private bool autorearm;

        //A Serial Port Arduino Input Can Change from one port to another when restared so...we have to find it.
        public bool AutoRearm
        {
            get { return autorearm; }
            set { SetProperty(ref autorearm, value); }
        }

        public ObservableCollection<SerialPort> ComPorts { get; } = new ObservableCollection<SerialPort>();

        private DelegateCommand refreshports;
        public DelegateCommand RefreshPorts =>
            refreshports ?? (refreshports = new DelegateCommand(ExecuteRefreshPorts));

        async void ExecuteRefreshPorts()
        {
            ComPorts.Clear();
            await Task.Delay(1000);

            foreach (var port in SerialPortManager.GetPortsInformation())
            {
                ComPorts.Add(new SerialPort(port));
            }
        }
        #endregion

        #region CallBack
        private string rawdata;
        public string  RawData
        {
            get { return rawdata; }
            set { SetProperty(ref rawdata, value); }
        }

        private void ReadData(bool sensoractive, string data)
        {
            if(sensoractive)
            {
                RawData = data;
                ProcessedViewModel.Instance.ReceiveData(data);
            }
            else
            {
                CaptureDataLabel = data;
            }
        }
        #endregion

        #region Visual 
        private string capturedatalabel;
        public string CaptureDataLabel
        {
            get { return capturedatalabel; }
            set { SetProperty(ref capturedatalabel, value); }
        }
        #endregion

    }


}
