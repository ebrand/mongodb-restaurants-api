using System;

namespace Restaurants.Models
{
    public class Address
    {
        public string BuildingNumber { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public decimal[] LatLongCoordinates { get; set; }

        public Address() {}
        public Address(string building, string street, string zipcode, decimal[] coord)
        {
            this.BuildingNumber = building;
            this.Street = street;
            this.PostalCode = zipcode;
            this.LatLongCoordinates = coord;
        }
    }
}