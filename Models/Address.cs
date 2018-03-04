using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurants.Models
{
    [BsonIgnoreExtraElements]
    public class Address
    {
        [BsonElement("building")]
        public string Building { get; set; }

        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("zipcode")]
        public string ZipCode { get; set; }

        [BsonElement("coord")]
        public object[] Coord { get; set; }

        public Address() {}
        public Address(string building, string street, string zipcode, object[] coord)
        {
            this.Building = building;
            this.Street = street;
            this.ZipCode = zipcode;
            this.Coord = coord;
        }
    }
}