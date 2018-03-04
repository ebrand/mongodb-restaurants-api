using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurants.Models
{
    [BsonIgnoreExtraElements]
    public class Restaurant
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("restaurant_id")]
        public string Restaurant_Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("borough")]
        public string Borough { get; set; }

        [BsonElement("cuisine")]
        public string Cuisine { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("grades")]
        public RestaurantGrade[] Grades { get; set; }

        public Restaurant() {}
        public Restaurant(ObjectId id, string rest_id, string name, string borough, string cuisine, Address address, RestaurantGrade[] grades)
        {
            this.Id = id;
            this.Restaurant_Id = rest_id;
            this.Name = name;
            this.Borough = borough;
            this.Cuisine = cuisine;
            this.Address = address;
            this.Grades = grades;
        }
    }
}