using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

#if ENABLE_WINMD_SUPPORT
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Foundation;
using Windows.Security.Cryptography;
#endif
public class BLETest : MonoBehaviour
{
    // Server GUID
    const string TargetDeviceName = "wang_iPhone";
    // Service GUID
    readonly Guid TargetServiceGuid = new Guid("00001819-0000-1000-8000-00805f9b34fb");
    // Characteristic GUID
    readonly Guid TargetCharGuid = new Guid("00002a67-0000-1000-8000-00805f9b34fb");


#if ENABLE_WINMD_SUPPORT
    private BluetoothLEAdvertisementWatcher watcher = null;
    private GattCharacteristic gattCharacteristic = null;
   
    private ulong bluetoothAddress = 0;
#endif

    private bool flag_connected = false;
    private bool flag_foundDevice = false;
    private SynchronizationContext context = null;

    private void Awake()
    {

    }

    void Start()
    {
        StartBleDeviceWatcher();

#if ENABLE_WINMD_SUPPORT
        
#endif
    }

    void Update()
    {
#if ENABLE_WINMD_SUPPORT
        //if(flag_ready)
        //{
        //    Recievedata();
        //}        
#endif
    }




    private void StartBleDeviceWatcher()
    {
        context = SynchronizationContext.Current;
        StartCoroutine(StartDevice());
        Task task = Task.Run(() =>
        {
            ReadFromBLE();
        });

#if ENABLE_WINMD_SUPPORT
/*
 ushort BEACON_ID = 0x004C;
        //EventCenter.Broadcast(EventType.ShowUserCoordinates, "OnStart.");
        watcher = new BluetoothLEAdvertisementWatcher();
        var manufacturerData = new BluetoothLEManufacturerData
        {
            CompanyId = BEACON_ID
        };


        //watcher.AdvertisementFilter.Advertisement.ManufacturerData.Add(manufacturerData);
        //watcher.AdvertisementFilter.Advertisement.LocalName = "wang_iPhone";
        watcher.Received += OnAdvertisementReceived;
        watcher.Start();
        */
        
#endif

    }

    private IEnumerator StartDevice()
    {
        yield return new WaitForSeconds(1);
#if ENABLE_WINMD_SUPPORT
        watcher = new BluetoothLEAdvertisementWatcher()
        {
            ScanningMode = BluetoothLEScanningMode.Active
        };
        watcher.Received += OnAdvertisementReceived;

        watcher.Start();
#endif
    }


#if ENABLE_WINMD_SUPPORT
    private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
    {
        if (!flag_connected && !flag_foundDevice)
        {
            BluetoothLEDevice device = await BluetoothLEDevice.FromBluetoothAddressAsync(eventArgs.BluetoothAddress);
            if (device != null && device.Name == TargetDeviceName)
            {
                flag_foundDevice = true;
                context.Post(__ =>
                {
                    EventCenter.Broadcast(EventType.ShowUserCoordinates, "Found device: " + device.Name);
                }, null);

                GattDeviceServicesResult gattRes = await device.GetGattServicesAsync();
                if (gattRes.Status == GattCommunicationStatus.Success)
                {
                    context.Post(__ =>
                    {
                        EventCenter.Broadcast(EventType.ShowUserCoordinates, "GATT services communicated.");
                    }, null);

                    foreach (var svc in gattRes.Services)
                    {
                        context.Post(__ =>
                        {
                            string s_guid = "GUID: " + svc.Uuid.ToString();
                            EventCenter.Broadcast(EventType.ShowUserCoordinates, s_guid);
                        }, null);

                        if (svc.Uuid.Equals(TargetServiceGuid))
                        {
                            context.Post(__ =>
                            {
                                EventCenter.Broadcast(EventType.ShowUserCoordinates, "Target GATT service found.");
                            }, null);

                            GattCharacteristicsResult charRes = await svc.GetCharacteristicsAsync();
                            if (charRes.Status == GattCommunicationStatus.Success)
                            {
                                context.Post(__ =>
                                {
                                    EventCenter.Broadcast(EventType.ShowUserCoordinates, "GATT characteristics communicated.");
                                }, null);
                                foreach (var chr in charRes.Characteristics)
                                {
                                    context.Post(__ =>
                                    {
                                        string c_guid = "GUID: " + chr.Uuid.ToString();
                                        EventCenter.Broadcast(EventType.ShowUserCoordinates, c_guid);
                                    }, null);

                                    if (chr.Uuid.Equals(TargetCharGuid))
                                    {
                                        context.Post(__ =>
                                        {
                                            EventCenter.Broadcast(EventType.ShowUserCoordinates, "Target GATT characteristic found.");
                                        }, null);


                                        gattCharacteristic = chr;
                                        gattCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);

                                        byte[] writeByte = new byte[] { 0x01, 0xFF, 0xFF, 0xFF, 0xFF, };
                                        gattCharacteristic.WriteValueAsync(CryptographicBuffer.CreateFromByteArray(writeByte), GattWriteOption.WriteWithResponse);

                                        flag_connected = true;

                                        context.Post(__ =>
                                        {
                                            EventCenter.Broadcast(EventType.ShowUserCoordinates, "GATT characteristic connected.");
                                        }, null);

                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

    }
#endif

    private async void ReadFromBLE()
    {
        await Task.Delay(3000);
#if ENABLE_WINMD_SUPPORT
        while (true)
        {
            if (flag_connected)
            {
                if (gattCharacteristic != null)
                {
                    GattReadResult result;
                    try
                    {
                        result = await gattCharacteristic.ReadValueAsync();
                    }
                    catch (global::System.Exception e)
                    {
                        flag_connected = false;
                        flag_foundDevice = false;
                        await Task.Delay(1000);
                        continue;
                    }

                    if (result?.Status == GattCommunicationStatus.Success)
                    {
                        context.Post(__ =>
                        {
                            EventCenter.Broadcast(EventType.ShowUserCoordinates, "GattCommunicationStatus.Success");
                        }, null);

                        byte[] data;
                        CryptographicBuffer.CopyToByteArray(result.Value, out data);
                        string str = BitConverter.ToString(data);

                        string[] arrStr = new string[data.Length];
                        for (int i = 0; i < data.Length; i++)
                        {
                            arrStr[i] = Convert.ToString(data[i], 2).PadLeft(8, '0');
                        }

                        string arrLat = "";
                        string arrLon = "";

                        arrLat = arrStr[7] + arrStr[6] + arrStr[5] + arrStr[4];
                        arrLon = arrStr[11] + arrStr[10] + arrStr[9] + arrStr[8];


                        Int32 Latitude = Convert.ToInt32(arrLat, 2);
                        Int32 Longitude = Convert.ToInt32(arrLon, 2);

                        double lat = (double)Latitude / Math.Pow(10, 7);
                        double lon = (double)Longitude / Math.Pow(10, 7);

                        context.Post(__ =>
                        {
                            EventCenter.Broadcast(EventType.ShowUserCoordinates, "Lattitude = " + lat + ", Longitude = " + lon);
                        }, null);
                    }
                    else
                    {
                        flag_connected = false;
                    }

                }

            }
            await Task.Delay(100);
        }
#endif
    }

}
