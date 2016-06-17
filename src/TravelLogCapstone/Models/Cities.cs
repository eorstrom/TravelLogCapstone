﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLogCapstone.Models
{
    public class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int AppUserId { get; set; }
        public ICollection<Restaurants> Restaurants { get; set; }
    }
}
