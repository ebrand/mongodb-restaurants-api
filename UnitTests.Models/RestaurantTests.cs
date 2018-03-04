using System;
using Shouldly;
using Restaurants.Models;
using Xunit;
using MongoDB.Bson;

namespace Restaurants.UnitTests.Models
{
    public class RestaurantTests
    {
        [Fact]
        public void Restaurant_Can_Be_Instantiated()
        {
            var rest = new Restaurant();
            rest.ShouldNotBeNull();
        }

        [Fact]
        public void Restaurant_Has_Valid_Properties()
        {
            var rest = new Restaurant(
                "1", 
                "Name", 
                "Borough", 
                "Cuisine", 
                new Address(), 
                new RestaurantGrade[]
                { 
                    new RestaurantGrade(DateTime.Now, "A", 0),
                    new RestaurantGrade(DateTime.Now, "B", 1)
                }
            );
            rest.restaurant_id.ShouldNotBeEmpty();
            rest.name.ShouldNotBeEmpty();
            rest.borough.ShouldNotBeEmpty();
            rest.cuisine.ShouldNotBeEmpty();
            rest.address.ShouldNotBeNull();
            rest.grades.ShouldNotBeNull();
            rest.grades.Length.ShouldBe(2);
            rest.grades[0].ShouldNotBeNull();
            rest.grades[1].ShouldNotBeNull();
        }
    }
}
