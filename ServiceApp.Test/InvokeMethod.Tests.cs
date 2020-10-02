using System;
using Xunit;
using SharedLibrary.Services;


namespace ServiceApp.Test
{
    public class InvokeMethodTests
    {
        [Fact]
        public void ShouldCheckThatPayloadIsConvertibleToAnInt()
        {
            var payload = "10";
            int expected = 10;
            int actual = 0;

            Int32.TryParse(payload, out actual);
            Assert.Equal(expected, actual);
        }

                         
        [Theory]
        [InlineData("DeviceApp", "SetTelemetryInterval", "5", "200")]
        [InlineData("DeviceApp", "GetTelemetryInterval", "5", "501")]

        public void ShouldGetResponsMessage(string targetDevice, string methodName, string payload, string expected) 
        {
            var service = new ServiceClientService("HostName=ec-win20iothub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=gpHmAu5J/VlUZ63wn3YdwS4YHa9jpS/1ztgSFZmBd7k=");
            var response = service.InvokeMetodAsync(targetDevice, methodName, payload);

            Assert.Equal(expected, response.Result.Status.ToString());
        }


    }
}
