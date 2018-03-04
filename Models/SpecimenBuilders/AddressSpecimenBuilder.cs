using System;
using System.Reflection;
using AutoFixture.Kernel;

namespace Restaurants.Models.SpecimenBuilders
{
    public class AddressSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var faker = Utilities.BogusManager.Instance.Faker;

            if (request is PropertyInfo propInfo && propInfo.ReflectedType == typeof(Address))
            {
                if (propInfo.Name == "Building" && propInfo.PropertyType != typeof(string))
                    return faker.Address.BuildingNumber();

                if (propInfo.Name == "Street" && propInfo.PropertyType != typeof(string))
                    return faker.Address.StreetAddress();

                if (propInfo.Name == "ZipCode" && propInfo.PropertyType != typeof(string))
                    return faker.Address.ZipCode(Utilities.Common.ZIP_CODE_FORMAT);
            }
            return new NoSpecimen();
        }
    }
}