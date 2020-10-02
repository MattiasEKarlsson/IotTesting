using SharedLibrary.Services;
using System;
using System.Threading.Tasks;

namespace ServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Delay(10*1000).Wait();

            DeviceServices.InvokeMethod("DeviceApp", "SetTelemetryInterval", "5").GetAwaiter();
            Console.ReadKey();
        }
    }
}
