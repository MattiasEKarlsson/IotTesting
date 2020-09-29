using Newtonsoft.Json;
using SharedLibrary.Models;
using System;
using Xunit;

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
    }
}
