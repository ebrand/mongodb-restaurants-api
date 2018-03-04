using System;
using Newtonsoft.Json;

namespace Restaurants.Models
{
    public class Address
    {
        [JsonProperty("building")]
        public string building { get; set; }

        [JsonProperty("street")]
        public string street { get; set; }

        [JsonProperty("zipcode")]
        public string zipcode { get; set; }

        [JsonProperty("coord")]
        public object[] coord { get; set; }

        public Address() {}
        public Address(string building, string street, string zipcode, object[] coord)
        {
            this.building = building;
            this.street = street;
            this.zipcode = zipcode;
            this.coord = coord;
        }
    }
}