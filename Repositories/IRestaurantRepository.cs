using System;
using System.Collections.Generic;
using Restaurants.Models;

namespace Restaurants.Repositories
{
    public interface IRestaurantRepository
    {
        Restaurant GetOne(string rest_id);

        List<Restaurant> GetMany(int count = -1);
    }
}