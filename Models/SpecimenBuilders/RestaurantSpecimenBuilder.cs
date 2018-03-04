using System;
using System.Reflection;
using AutoFixture.Kernel;
using MongoDB.Bson;

namespace Restaurants.Models.SpecimenBuilders
{
    public class RestaurantSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var faker = Utilities.BogusManager.Instance.Faker;

            if (request is PropertyInfo propInfo && propInfo.ReflectedType == typeof(Restaurant))
            {
                if (propInfo.Name == "Id" && propInfo.ReflectedType != typeof(string))
                    return ObjectId.GenerateNewId();

                if (propInfo.Name == "Restaurant_Id" && propInfo.PropertyType != typeof(string))
                    return faker.IndexGlobal.ToString();

                if (propInfo.Name == "Name" && propInfo.PropertyType != typeof(string))
                    return faker.Company.CompanyName(formatIndex: 0);

                if (propInfo.Name == "Borough" && propInfo.PropertyType != typeof(string))
                    return faker.Address.County();

                if (propInfo.Name == "Cuisine" && propInfo.PropertyType != typeof(string))
                    return faker.Lorem.Word();
            }
            return new NoSpecimen();
        }
    }
}