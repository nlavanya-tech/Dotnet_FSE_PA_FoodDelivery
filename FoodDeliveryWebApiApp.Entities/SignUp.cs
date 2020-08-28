using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDeliveryWebApiApp.Entities
{
    public class SignUp
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string NewPassword { get; set; }
    }
}
