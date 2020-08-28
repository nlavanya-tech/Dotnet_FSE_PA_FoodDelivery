using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodDeliveryWebApiApp.Entities
{
    public class Orders
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }
        public string FoodItem { get; set; }
        public int Cost { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }



    }
}
