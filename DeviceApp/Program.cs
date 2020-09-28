using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Models;
using static SharedLibrary.Models.TemperatureApiModel;
using SharedLibrary.Services;

namespace DeviceApp
{
    class Program
    {

        
        

        static void Main(string[] args)
        {
            DeviceServices.deviceClient.SetMethodHandlerAsync("SetTelemetryInterval", DeviceServices.SetTelemetryInterval, null).Wait();
            DeviceServices.SendMessageAsync().GetAwaiter();

            Console.ReadKey();
        }

        
    }
}
