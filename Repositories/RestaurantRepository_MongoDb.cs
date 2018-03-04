﻿using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Restaurants.Models;

namespace Restaurants.Repositories
{
    public class RestaurantRepository_MongoDb : IRestaurantRepository
    {

        MongoClient _client;
        IMongoDatabase _db;
        IMongoCollection<Restaurant> _restaurants;

        public RestaurantRepository_MongoDb()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("test");
            _restaurants = _db.GetCollection<Restaurant>("restaurants");
        }

        public List<Restaurant> GetMany(int count = -1)
        {
            return (count > 0)
                ? _restaurants.Find(new BsonDocument()).Limit(count).ToList()
                : _restaurants.Find(new BsonDocument()).ToList();
        }

        public Restaurant GetOne(string rest_id)
        {
            return _restaurants.Find(
                new BsonDocument(
                    new BsonElement("restaurant_id", rest_id)
                )
            ).Single();
        }
    }
}