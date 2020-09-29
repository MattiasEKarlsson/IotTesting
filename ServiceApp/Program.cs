using Microsoft.Azure.Devices;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ServiceApp
{
    class Program
    {
        private static ServiceClient serviceClient = ServiceClient.CreateFromConnectionString("HostName=ec-win20iothub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=gpHmAu5J/VlUZ63wn3YdwS4YHa9jpS/1ztgSFZmBd7k=");
        static void Main(string[] args)
        {
            Task.Delay(10*1000).Wait();

            InvokeMethod("DeviceApp", "SetTelemetryInterval", "5").GetAwaiter();
            Console.ReadKey();
        }

        static async Task InvokeMethod(string deviceId, string methodName, string payload)
        {
            var methodInvocation = new CloudToDeviceMethod(methodName) { ResponseTimeout = TimeSpan.FromSeconds(30) };
            methodInvocation.SetPayloadJson(payload);
            Console.WriteLine(payload);

            var response = await serviceClient.InvokeDeviceMethodAsync(deviceId, methodInvocation);
            Console.WriteLine($"Response Status: {response.Status}");
            Console.WriteLine(response.GetPayloadAsJson());

        }
    }
}
