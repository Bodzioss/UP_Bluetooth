using System;
using System.IO;
using System.Windows.Controls;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace Bluetooth_m
{
    class OurBluetooth
    {
        BluetoothDeviceInfo[] _devices;

        public static BluetoothDeviceInfo[] scanRemoteDevices()
        {
            BluetoothDeviceInfo[] _devices;
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            BluetoothClient client = new BluetoothClient();
            _devices = client.DiscoverDevicesInRange();
            return _devices;
        }

        private FileInfo[] files;
        public void listFiles(ComboBox comboBox)
        {
            string currentPathDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo dirInfo = new DirectoryInfo(currentPathDirectory);
            files = dirInfo.GetFiles();
            int i = -1;
            foreach (FileInfo f in files)
            {
               comboBox.Items.Add(f.Name);
            }
        }

        public FileInfo[] getListOfFile(FileInfo[] mFiles)
        {
            return files;
        }

        public String getFilePath(int fileIndex)
        {
            if (inRangeIndex(fileIndex))
            {
                return files[fileIndex].FullName;
            }

            return null;
        }

        public String getFilePath(String fileName)
        {
            foreach (var fileIndex in files)
            {
                if (fileIndex.Name == fileName)
                {
                    return fileIndex.FullName;
                }
            }
            return null;
        }

        private bool inRangeIndex(int index)
        {
            bool correctRange = (index >= 0 && index < files.Length);
            if (!correctRange)
            {
                Console.WriteLine("Incorrect index range");
            }
            return correctRange;
        }

        public String sendFile(String pathToFile, BluetoothDeviceInfo device,Label titleLabel)
        {
            bool fileExists = pathToFile != null;
          //  bool correctDeviceRange = inRangeIndex(index);
          string error;

            if (fileExists)
            {
                var file = @pathToFile;
                var uri = new Uri("obex://" + device.DeviceAddress + "/" + file);
                var request = new ObexWebRequest(uri);
                request.ReadFile(file);
                var response = (ObexWebResponse)request.GetResponse();
                error = (response.StatusCode.ToString());
                response.Close();
                return error;
            }
            else
            {
            error = "Złe parametry";
            return error;
            }
        }



    }
}
