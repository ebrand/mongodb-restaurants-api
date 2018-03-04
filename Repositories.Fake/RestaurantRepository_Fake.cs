using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Restaurants.Models;

namespace Restaurants.Repositories.Fake
{
    public class RestaurantRepository_Fake : IRestaurantRepository
    {
        List<Restaurant> _restaurants;

        public RestaurantRepository_Fake()
        {
            int NUM_FAKES_TO_CREATE = 1000;

            var addresses = new Faker<Address>()
                .RuleFor(a => a.building, f => f.Address.BuildingNumber())
                .RuleFor(a => a.street, f => f.Address.StreetAddress())
                .RuleFor(a => a.zipcode, f => f.Address.ZipCode(Utilities.Common.ZIP_CODE_FORMAT));
            
            var restGrades = new Faker<RestaurantGrade>()
                .RuleFor(rg => rg.date, f => f.Date.Past(10))
                .RuleFor(rg => rg.grade, f => f.PickRandom(Utilities.Common.GRADE_VALUES))
                .RuleFor(rg => rg.score, f => f.Random.Number(0, 100));
            
            _restaurants = new Faker<Restaurant>()

                .RuleFor(r => r.restaurant_id, f => f.IndexGlobal.ToString())
                .RuleFor(r => r.name, f => f.Company.CompanyName())
                .RuleFor(r => r.borough, f => f.Address.County())
                .RuleFor(r => r.cuisine, f => f.Lorem.Word())
                .RuleFor(r => r.address, f => addresses.Generate(1).Single())
                .RuleFor(r => r.grades, f => restGrades.Generate(f.Random.Number(1,5)).ToArray())
            
                .Generate(NUM_FAKES_TO_CREATE);
        }

        public List<Restaurant> GetMany()
        {
            return _restaurants;
        }

        public Restaurant GetOne(string rest_id)
        {
            return _restaurants.FirstOrDefault(r => r.restaurant_id == rest_id);
        }
    }
}