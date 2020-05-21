using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsConsumoWepApi.Models
{
    public class TemperatureStatistics
    {
        public DateTime firstDate { get; set; }
        public DateTime lastDate { get; set; }
        public double minTemp { get; set; }
        public double maxTemp { get; set; }
        public double avgTemp { get; set; }
        public string cityName { get; set; }
        public double total { get; set; }

    }
}

