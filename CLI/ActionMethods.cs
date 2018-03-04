using System;
using PowerArgs;
using Restaurants.Repositories;
using Restaurants.Repositories.MongoDb;
using Utilities;

namespace Restaurants.CLI
{
    public class ActionMethods
    {
        [ArgActionMethod]
        public void restaurants()
        {
            IRestaurantRepository repo = new RestaurantRepository_MongoDb();
            foreach (var r in repo.GetMany())
                Console.WriteLine(r.ToJson(true));
        }
    }
}