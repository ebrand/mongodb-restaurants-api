using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Bogus;
using MongoDB.Bson;
using Restaurants.Models;
using Restaurants.Models.SpecimenBuilders;

namespace Restaurants.Repositories
{
    public class RestaurantRepository_Fake : IRestaurantRepository
    {
        List<Restaurant> _restaurants;

        public RestaurantRepository_Fake()
        {
            int NUM_FAKES_TO_CREATE = 1000;

            var addresses = new Faker<Address>()
                .RuleFor(a => a.Building, f => f.Address.BuildingNumber())
                .RuleFor(a => a.Street, f => f.Address.StreetAddress())
                .RuleFor(a => a.ZipCode, f => f.Address.ZipCode(Utilities.Common.ZIP_CODE_FORMAT));
            
            var restGrades = new Faker<RestaurantGrade>()
                .RuleFor(rg => rg.Date, f => f.Date.Past(10))
                .RuleFor(rg => rg.Grade, f => f.PickRandom(Utilities.Common.GRADE_VALUES))
                .RuleFor(rg => rg.Score, f => f.Random.Number(0, 100));
            
            _restaurants = new Faker<Restaurant>()
            
                .RuleFor(r => r.Id, ObjectId.GenerateNewId())
                .RuleFor(r => r.Restaurant_Id, f => f.IndexGlobal.ToString())
                .RuleFor(r => r.Name, f => f.Company.CompanyName())
                .RuleFor(r => r.Borough, f => f.Address.County())
                .RuleFor(r => r.Cuisine, f => f.Lorem.Word())
                .RuleFor(r => r.Address, f => addresses.Generate(1).Single())
                .RuleFor(r => r.Grades, f => restGrades.Generate(f.Random.Number(1,5)).ToArray())
            
                .Generate(NUM_FAKES_TO_CREATE);
        }

        public List<Restaurant> GetMany(int count = -1)
        {
            return (count > 0)
                ? _restaurants.Take(count).ToList()
                : _restaurants;
        }

        public Restaurant GetOne(string rest_id)
        {
            return _restaurants.FirstOrDefault(r => r.Restaurant_Id == rest_id);
        }
    }
}