using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDeliveryWebApiApp.Entities
{
    public class FoodItems
    {
        public string FoodItem { get; set; }
        public int Cost { get; set; }
        public string Address { get; set; }
        public string RestorentName { get; set; }
    }
}
