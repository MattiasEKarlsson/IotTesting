using Newtonsoft.Json;
using SharedLibrary.Models;
using System;
using Xunit;

namespace DeviceApp.Test
{
    public class SentMessageAsyncTest
    {
        [Fact]
        public void ShouldConvertObjectJsonFormat()
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
