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
                ObjectId.GenerateNewId(),
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
            rest.Restaurant_Id.ShouldNotBeEmpty();
            rest.Name.ShouldNotBeEmpty();
            rest.Borough.ShouldNotBeEmpty();
            rest.Cuisine.ShouldNotBeEmpty();
            rest.Address.ShouldNotBeNull();
            rest.Grades.ShouldNotBeNull();
            rest.Grades.Length.ShouldBe(2);
            rest.Grades[0].ShouldNotBeNull();
            rest.Grades[1].ShouldNotBeNull();
        }
    }
}
