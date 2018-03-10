using System;
using System.Collections.Generic;
using PowerArgs;
using RestSharp;
using Utilities;
using Restaurants.Models;

namespace Restaurants.CLI
{
    public class ActionMethods
    {
        [ArgActionMethod]
        public void restaurants()
        {
            var client = new RestSharp.RestClient("http://API/api/restaurants");
            var response = client.Get<List<Restaurant>>(new RestRequest());
            var rests = response.Data;
            Console.WriteLine(rests.ToJson(true));
        }

        [ArgActionMethod]
        public void restaurant(RestIdArg arg)
        {
            var client = new RestSharp.RestClient(string.Format("http://API/api/restaurants/{0}", arg.RestId));
            var response = client.Get<Restaurant>(new RestRequest());
            var rest = response.Data;
            Console.WriteLine(rest.ToJson(true));
        }

        public class RestIdArg
        {
            [ArgRequired, ArgDescription("The restaurant ID to retrieve."), ArgPosition(1)]
            public string RestId { get; set; }
        }
    }
}