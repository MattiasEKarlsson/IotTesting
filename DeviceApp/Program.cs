using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Models;
using static SharedLibrary.Models.TemperatureApiModel;

namespace DeviceApp
{
    class Program
    {

        private static DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=ec-win20iothub.azure-devices.net;DeviceId=DeviceApp;SharedAccessKey=sJGB59/d4EwPyNVxsX/VXWzxQoZkivpeYQUN+Bu7j+k=");
        private static int telemetryInterval = 5;
        

        static void Main(string[] args)
        {
            deviceClient.SetMethodHandlerAsync("SetTelemetryInterval", SetTelemetryInterval, null).Wait();
            SendMessageAsync().GetAwaiter();

            Console.ReadKey();
        }

        private static Task<MethodResponse> SetTelemetryInterval(MethodRequest request, object userContext)
        {
            var payload = Encoding.UTF8.GetString(request.Data).Replace("\"", "");

            if (Int32.TryParse(payload, out telemetryInterval))
            {
                Console.WriteLine($"Interval set to: {telemetryInterval} seconds.");

                // { "result": "Executed direct method: SetTelemetryInterval" }
                string json = "{\"result\": \"Executed direct method: " + request.Name + "\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(json), 200));
            }
            else
            {
                string json = "{\"result\": \"Method not implemented\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(json), 501));
            }
        }

        private static async Task SendMessageAsync()
        {
            var httpClient = HttpClientFactory.Create();

            while (true)
            {
                double temp = 0;
                int humidity = 0;
                TemperatureModel senddata = new TemperatureModel();

                try
                {
                    var url = "https://api.openweathermap.org/data/2.5/onecall?lat=59.27412&units=metric&lon=15.2066&exclude=hourly,daily,minutely&appid=5bf919005c4c20e778ba98f74c7f2e33";
                    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var content = httpResponseMessage.Content;                                    //Hämtar Api
                        var datatemp = await content.ReadAsAsync<Rootobject>();

                        temp = datatemp.current.temp;                                                // Sätter Temp och Humidity
                        humidity = datatemp.current.humidity;

                        senddata = new TemperatureModel                                              //Lägger Temp och Humidity i samma objekt.
                        {
                            Temperature = temp,
                            Humidity = humidity
                        };

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    var json = JsonConvert.SerializeObject(senddata);                                        // Converterar till Json format.

                    var payload = new Message(Encoding.UTF8.GetBytes(json));                             // Packeterar meddelandena

                    await deviceClient.SendEventAsync(payload);                                         // Skickar

                    Console.WriteLine($"Message Sent: {json}");
                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                }

                await Task.Delay(telemetryInterval * 1000);
            }
        }
    }
}
