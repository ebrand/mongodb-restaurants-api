using System;
using System.Collections.Generic;
using Restaurants.Models;

namespace Restaurants.Repositories
{
    public interface IRestaurantRepository
    {
        List<Restaurant> GetMany();

        Restaurant GetOne(string rest_id);
    }
}