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
    }
}

