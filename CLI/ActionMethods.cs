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

        [ArgActionMethod]
        public void restaurant(RestIdArg arg)
        {
            IRestaurantRepository repo = new RestaurantRepository_MongoDb();
            Console.WriteLine(repo.GetOne(arg.RestId).ToJson(true));
        }

        public class RestIdArg
        {
            [ArgRequired, ArgDescription("The restaurant ID to retrieve."), ArgPosition(1)]
            public string RestId { get; set; }
        }
    }
}