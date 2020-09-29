using System;
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
