using System;
using Shouldly;
using Utilities;
using Xunit;

namespace UnitTests.Utilities
{
    public class BogusManagerTests
    {
        [Fact]
        public void Bogus_Manager_Exposes_Faker()
        {
            var faker = BogusManager.Instance.Faker;
            faker.ShouldNotBeNull();
            var countryCode = faker.Address.CountryCode(Bogus.DataSets.Iso3166Format.Alpha2);
            countryCode.ShouldNotBeNullOrEmpty();
            countryCode.Length.ShouldBe(2);
        }
    }
}