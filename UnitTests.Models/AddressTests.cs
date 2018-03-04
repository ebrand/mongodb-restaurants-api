using System;
using Restaurants.Models;
using Shouldly;
using Xunit;

namespace Restaurants.UnitTests.Models
{
    public class AddressTests
    {
        [Fact]
        public void Address_Can_Be_Instantiated()
        {
            var addr = new AddressTests();
            addr.ShouldNotBeNull();
        }

        [Fact]
        public void Address_Has_Valid_Properties()
        {
            var coord0 = -73.961704M;
            var coord1 = 40.662942M;

            var addr = new Address("Building", "Street", "ZipCode", new object[]{coord0, coord1});
            addr.building.ShouldNotBeEmpty();
            addr.street.ShouldNotBeEmpty();
            addr.zipcode.ShouldNotBeEmpty();
            addr.coord.ShouldNotBeNull();
            addr.coord.Length.ShouldBe(2);
            addr.coord.GetValue(0).ShouldBe(coord0);
            addr.coord.GetValue(1).ShouldBe(coord1);
        }
    }
}