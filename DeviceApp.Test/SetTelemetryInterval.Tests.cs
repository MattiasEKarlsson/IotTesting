using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedLibrary.Models;
using System;
using System.Text;
using Xunit;

namespace DeviceApp.Test
{
    public class SetTelemetryIntervalTests
    {
        [Fact]
        public void ShouldConvertObjectToJsonFormat()
        {
            TemperatureModel json = new TemperatureModel
            {
                Temperature = 18.31,
                Humidity = 68
            };

            string expected = "{\"Temperature\":18.31,\"Humidity\":68.0}";
            string actual = JsonConvert.SerializeObject(json);
            Assert.Equal(expected, actual);

        }



        //    public static DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=ec-win20iothub.azure-devices.net;DeviceId=DeviceApp;SharedAccessKey=sJGB59/d4EwPyNVxsX/VXWzxQoZkivpeYQUN+Bu7j+k=");
        //    [Theory]
        //    [InlineData("SetTelemetryInterval", "5", 200)]
        //    [InlineData("SettTelemetryIterval", "5", 501)]
        //    public void SetTelemetryInterval_ShouldChangeTheInterval(string methodName, string payload, int statusCode)
        //    {
        //        var result = Encoding.UTF8.GetString(request.Data);

        //        int expected = statusCode;
        //        int actual = ;


        //}   }








    }
}

