using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Restaurants.Models;

namespace Restaurants.Repositories.MongoDb
{
    public class RestaurantRepository_MongoDb : IRestaurantRepository
    {

        MongoClient _client;
        IMongoDatabase _db;
        IMongoCollection<Restaurant> _restaurants;

        public RestaurantRepository_MongoDb()
        {
            // configure MongoDB conventions and model mappings
            ConfigureMongoConventionsAndMappings();

            _client = new MongoClient("mongodb://172.17.0.2:27017");
            _db = _client.GetDatabase("test");
            _restaurants = _db.GetCollection<Restaurant>("restaurants");
        }

        public List<Restaurant> GetMany()
        {
            return _restaurants.Find(new BsonDocument()).ToList();
        }

        public Restaurant GetOne(string rest_id)
        {
            return _restaurants.Find(
                new BsonDocument(
                    new BsonElement("restaurant_id", rest_id)
                )
            ).Single();
        }

        private void ConfigureMongoConventionsAndMappings()
        {
            // register a global convention for MongoDB to ignore extranneous
            // properties when de/serializing.
            ConventionRegistry.Register(
                "Ignore extra elements convention for the 'Restaurants.Models.*' namespace.",
                new ConventionPack { new IgnoreExtraElementsConvention(ignoreExtraElements: true) },
                t => t.FullName.StartsWith("Restaurants.Models.", StringComparison.InvariantCulture)
            );

            // map JSON properties to domain model properties for us in de/serializing.
            BsonClassMap.RegisterClassMap<Restaurant>(cm =>
            {
                cm.MapMember(r => r.Address).SetElementName("address");
                cm.MapMember(r => r.Borough).SetElementName("borough");
                cm.MapMember(r => r.Cuisine).SetElementName("cuisine");
                cm.MapMember(r => r.Grades).SetElementName("grades");
                cm.MapMember(r => r.Name).SetElementName("name");
            });

            BsonClassMap.RegisterClassMap<Address>(cm =>
            {
                cm.MapMember(a => a.BuildingNumber).SetElementName("building");
                cm.MapMember(a => a.LatLongCoordinates).SetElementName("coord");
                cm.MapMember(a => a.PostalCode).SetElementName("zipcode");
                cm.MapMember(a => a.Street).SetElementName("street");
            });

            BsonClassMap.RegisterClassMap<RestaurantGrade>(cm =>
            {
                cm.MapMember(rg => rg.Date).SetElementName("date");
                cm.MapMember(rg => rg.LetterGrade).SetElementName("grade");
                cm.MapMember(rg => rg.NumericScore).SetElementName("score");
            });
        }
    }
}