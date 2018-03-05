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
            CreateFakeData(10);
        }

        public List<Restaurant> GetMany()
        {
            return _restaurants;
        }

        public Restaurant GetOne(string rest_id)
        {
            return _restaurants.FirstOrDefault(r => r.RestaurantId == rest_id);
        }

        private void CreateFakeData(int count)
        {
            var addresses = new Faker<Address>()
                .RuleFor(a => a.BuildingNumber, f => f.Address.BuildingNumber())
                .RuleFor(a => a.Street, f => f.Address.StreetAddress())
                .RuleFor(a => a.PostalCode, f => f.Address.ZipCode(Utilities.Common.ZIP_CODE_FORMAT))
                .RuleFor(a => a.LatLongCoordinates, f => new decimal[] { f.Random.Decimal(-100.0M, 100.0M), f.Random.Decimal(-100.0M, 100.0M) });

            var restGrades = new Faker<RestaurantGrade>()
                .RuleFor(rg => rg.Date, f => f.Date.Past(10))
                .RuleFor(rg => rg.LetterGrade, f => f.PickRandom(Utilities.Common.GRADE_VALUES))
                .RuleFor(rg => rg.NumericScore, f => f.Random.Number(0, 100));

            _restaurants = new Faker<Restaurant>()

                .RuleFor(r => r.RestaurantId, f => f.IndexFaker.ToString())
                .RuleFor(r => r.Name, f => f.Company.CompanyName())
                .RuleFor(r => r.Borough, f => f.Address.County())
                .RuleFor(r => r.Cuisine, f => f.Lorem.Word())
                .RuleFor(r => r.Address, f => addresses.Generate(1).Single())
                .RuleFor(r => r.Grades, f => restGrades.Generate(f.Random.Number(1, 3)).ToArray())

                .Generate(count);
        }
    }
}