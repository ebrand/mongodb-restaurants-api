using System;
using Restaurants.Models;
using Shouldly;
using Xunit;

namespace Restaurants.UnitTests.Models
{
    public class RestaurantGradeTests
    {
        [Fact]
        public void RestaurantGrade_Can_Be_Instantiated()
        {
            var rg = new RestaurantGrade();
            rg.ShouldNotBeNull();
        }

        [Fact]
        public void RestaurantGrade_Has_Valid_Properties()
        {
            var rg = new RestaurantGrade(DateTime.Now, "A", 1);
            rg.Date.ShouldNotBeNull();
            rg.Grade.ShouldNotBeEmpty();
            rg.Score.ShouldNotBe(0);
        }
    }
}