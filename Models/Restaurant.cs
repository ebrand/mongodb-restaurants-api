using System;
//using Newtonsoft.Json;

namespace Restaurants.Models
{
    public class Restaurant
    {
        //[BsonProperty("restaurant_id")]
        public string restaurant_id { get; set; }

        //[JsonProperty("name")]
        public string name { get; set; }

        //[JsonProperty("borough")]
        public string borough { get; set; }

        //[JsonProperty("cuisine")]
        public string cuisine { get; set; }

        //[JsonProperty("address")]
        public Address address { get; set; }

        //[JsonProperty("grades")]
        public RestaurantGrade[] grades { get; set; }

        public Restaurant() {}
        public Restaurant(string rest_id, string name, string borough, string cuisine, Address address, RestaurantGrade[] grades)
        {
            this.restaurant_id = rest_id;
            this.name = name;
            this.borough = borough;
            this.cuisine = cuisine;
            this.address = address;
            this.grades = grades;
        }
    }
}