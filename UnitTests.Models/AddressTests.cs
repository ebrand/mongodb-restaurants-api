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
            addr.Building.ShouldNotBeEmpty();
            addr.Street.ShouldNotBeEmpty();
            addr.ZipCode.ShouldNotBeEmpty();
            addr.Coord.ShouldNotBeNull();
            addr.Coord.Length.ShouldBe(2);
            addr.Coord.GetValue(0).ShouldBe(coord0);
            addr.Coord.GetValue(1).ShouldBe(coord1);
        }
    }
}