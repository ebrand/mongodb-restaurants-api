using System;
using System.Reflection;
using AutoFixture.Kernel;

namespace Restaurants.Models.SpecimenBuilders
{
    public class RestaurantGradeSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var faker = Utilities.BogusManager.Instance.Faker;

            if (request is PropertyInfo propInfo && propInfo.ReflectedType == typeof(RestaurantGrade))
            {
                if (propInfo.Name == "Date" && propInfo.PropertyType != typeof(DateTime))
                    return faker.Date.Past(10);

                if (propInfo.Name == "Grade" && propInfo.PropertyType != typeof(string))
                    return faker.PickRandom(Utilities.Common.GRADE_VALUES);

                if (propInfo.Name == "Score" && propInfo.PropertyType != typeof(int))
                    return faker.Random.Number(0, 100);
            }
            return new NoSpecimen();
        }
    }
}