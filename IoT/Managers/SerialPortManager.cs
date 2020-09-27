using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace IoT
{
    public class SerialPortManager
    {
        public static List<(string name, string description)> GetPortsInformation()
        {
            using (var searcher = new ManagementObjectSearcher
                ("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();

                return (from n in portnames
                        join p in ports on n equals p["DeviceID"].ToString()
                        select (n, (string)p["Caption"])).ToList();
            }
        }
    }
}
