using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace Bluetooth_m
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          

        }
        BluetoothDeviceInfo[] _devices;
        private string errorMessage;
         private static readonly Guid NXT_GUID = BluetoothService.SerialPort;
        private List<BluetoothDeviceInfo> devices = new List<BluetoothDeviceInfo>();
        OurBluetooth bluetooth = new OurBluetooth();
        private int currentDeviceIndex;
        private void findDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            bluetooth.listFiles(fileComboBox);

            titleLabel.Content="***********||***********";
           
           
            _devices=OurBluetooth.scanRemoteDevices();
            List<String> deviceData = new List<String>();
        
            if (_devices == null)
            {
                Console.Write("Should be scanned first");
            }
            else
            {
                int i = 0;
                foreach (BluetoothDeviceInfo device in _devices)
                {
                    deviceData.Add("Autoryzacja: "+device.Authenticated.ToString());
                    deviceData.Add("Klasa: " +device.ClassOfDevice.ToString());
                    deviceData.Add("Połączenia: "+device.Connected.ToString());
                    deviceData.Add("Adres: " +device.DeviceAddress.ToString());
                    deviceData.Add("Nazwa: "+device.DeviceName.ToString());
                    deviceData.Add("Usługi: "+device.InstalledServices.ToString());
                    deviceData.Add("Ostatnio widziany: "+device.LastSeen.ToString());
                    deviceData.Add("Ostatnio uzywany: "+device.LastUsed.ToString());
                    deviceData.Add("Zapamietany: "+device.Remembered.ToString());
                    deviceData.Add("RSSI: " +device.Rssi.ToString());
                    deviceDataGrid.ItemsSource = deviceData.ToArray();
                    deviceComboBox.Items.Add(device.DeviceName.ToString());
                    recieverComboBox.Items.Add(device.DeviceName.ToString());


                }
            }
            
        }

        private void findAdapterButton_Click(object sender, RoutedEventArgs e)
        {
            
            BluetoothRadio[] radios = BluetoothRadio.AllRadios;

            foreach(BluetoothRadio radio in radios)
            {
                showRadioInfo(radio,deviceDataGrid);
            }

        }

        private static void showRadioInfo(BluetoothRadio radio,DataGrid deviceDataGrid)
        {

            List<String> adaptersData = new List<String>();
            if (radio == null)
            {
                radio = BluetoothRadio.PrimaryRadio;
            }

            if (radio != null)
            {
                RadioMode mode = radio.Mode;
                adaptersData.Add("Nazwa: "+radio.Name);
                adaptersData.Add("Manufacturer: " + radio.Manufacturer.ToString());
                adaptersData.Add("Klasa: "+radio.ClassOfDevice.ToString());
                adaptersData.Add("Status: " +radio.HardwareStatus.ToString());
                adaptersData.Add ("Adres: " +radio.LocalAddress.ToString());
                adaptersData.Add("S Manufacturer: " +radio.SoftwareManufacturer.ToString());
                deviceDataGrid.ItemsSource = adaptersData.ToArray();
            }
            else
            {
                Console.WriteLine("No primary radio");
            }
        }



        private void connectButton_Click_1(object sender, RoutedEventArgs e)
        {
            int selectedDeviceIndex= deviceComboBox.SelectedIndex;
            titleLabel.Content=_devices[selectedDeviceIndex].DeviceName.ToString();

            BluetoothSecurity.PairRequest(_devices[selectedDeviceIndex].DeviceAddress, "1111");

        }

        private void sendFileButton_Click(object sender, RoutedEventArgs e)
        {
            int fileIndex = Convert.ToInt32(fileComboBox.SelectedIndex);
            string filePath = bluetooth.getFilePath(fileIndex);

            int deviceIndex = recieverComboBox.SelectedIndex;
            titleLabel.Content=bluetooth.sendFile(filePath, _devices[deviceIndex],titleLabel);

        }



        private void getFileButton_Click(object sender, RoutedEventArgs e)
        {
            filesList.Items.Add(fileComboBox.SelectedItem.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            filesList.Items.RemoveAt(filesList.SelectedIndex);
        }

        private void sendAllButton_Click(object sender, RoutedEventArgs e)
        {
            filesSendProgressBar.Maximum=filesList.Items.Count;
            FileInfo[] files;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += sendAllFiles;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

     

        private void sendAllFiles(object sender, DoWorkEventArgs e)
        {
          
            for (int i = 0; i < filesList.Items.Count; i++)
            {
                string fileName = filesList.Items.GetItemAt(i).ToString();
                string filePath = bluetooth.getFilePath(fileName);
                errorMessage=bluetooth.sendFile(filePath, _devices[currentDeviceIndex], titleLabel);
                (sender as BackgroundWorker).ReportProgress(i+1);
                Application.Current.Dispatcher.BeginInvoke(new Action(() => { titleLabel.Content = errorMessage;}));
            }

            Thread.Sleep(2000);
            (sender as BackgroundWorker).ReportProgress(0);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            filesSendProgressBar.Value = e.ProgressPercentage;
        }

        private void recieverComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentDeviceIndex = recieverComboBox.SelectedIndex;
           
        }
    }
}
