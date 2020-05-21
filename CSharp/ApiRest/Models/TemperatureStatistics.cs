using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Models
{
    public class TemperatureStatistics
    {
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public double AvgTemp { get; set; }
        public string CityName { get; set; }
        public double Total { get; set; }
    }
}