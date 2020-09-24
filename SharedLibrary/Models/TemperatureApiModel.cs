using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class TemperatureApiModel
    {
        public class Rootobject
        {
            public Current current { get; set; }
        }

        public class Current
        {
            public double temp { get; set; }
            public int humidity { get; set; }
        }
    }
}
