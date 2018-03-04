using System;
using MongoDB.Bson;
using PowerArgs;
using Restaurants.Repositories;
using Utilities;

namespace Restaurants.CLI
{
    public class ActionMethods
    {
        [ArgActionMethod]
        public void restaurants(TestArgs args)
        {
            IRestaurantRepository repo = new RestaurantRepository_MongoDb();
            foreach (var r in repo.GetMany(args.Count))
                Console.WriteLine(r.ToJson(true));
        }
    }

    public class TestArgs
    {
        [ArgDescription("The number of restaurants to return in a sinlge call."), ArgPosition(1)]
        public int Count { get; set; }
    }
}