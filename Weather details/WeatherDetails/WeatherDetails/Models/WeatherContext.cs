﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherDetails.Models
{
    public class WeatherContext:DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        { }
        public DbSet<ClimateDetails> WDetails { get; set; }
    }
}
