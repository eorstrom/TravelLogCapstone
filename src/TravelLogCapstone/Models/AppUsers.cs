using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLogCapstone.Models
{
    public class AppUsers
    {
        [Key]
        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<Cities> Cities { get; set; }
        public Restaurants Restaurants { get; set; }
    }
}
