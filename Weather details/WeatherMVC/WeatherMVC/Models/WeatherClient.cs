using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherMVC.Models
{
    public partial class WeatherClient
    {
        
        public string City { get; set; }
        public DateTime Date { get; set; }       
        public float HighTemp { get; set; }
        public float LowTemp { get; set; }
        public string ForCast { get; set; }
    }
}
