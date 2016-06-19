using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelLogCapstone.Models
{
    public class Restaurants
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string FoodEaten { get; set; }
        public string DrinksConsumed { get; set; }
        public int ServiceRating { get; set; }
        public int OverallRating { get; set; }
        public int CleanlinessRating { get; set; }
        public string FoodCategory { get; set; }
        public string UserNotes { get; set; }
        public int CityId { get; set; }
        public Cities Cities { get; set; }
    }
}
