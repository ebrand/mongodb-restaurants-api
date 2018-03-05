using System;

namespace Restaurants.Models
{
    public class Restaurant
    {
        public string RestaurantId { get; set; }

        public string Name { get; set; }

        public string Borough { get; set; }

        public string Cuisine { get; set; }

        public Address Address { get; set; }

        public RestaurantGrade[] Grades { get; set; }

        public Restaurant() {}
        public Restaurant(string rest_id, string name, string borough, string cuisine, Address address, RestaurantGrade[] grades)
        {
            this.RestaurantId = rest_id;
            this.Name = name;
            this.Borough = borough;
            this.Cuisine = cuisine;
            this.Address = address;
            this.Grades = grades;
        }
    }
}