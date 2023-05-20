using Bogus;
using Core.Models;
using Core.Utilites.Configuration;
using Core.Utilites.Helpers;

namespace SaucedemoTests.Models.Utilities
{
    internal class CheckoutDataBuilder
    {
        static readonly Faker faker = new();

        public static CheckoutData StandartCheckoutData => new()
        {
            FirstName = Configurator.Configuration.GetSection("StandartCheckoutData")["FirstName"]!,
            LastName = Configurator.Configuration.GetSection("StandartCheckoutData")["LastName"]!,
            ZipCode = Configurator.Configuration.GetSection("StandartCheckoutData")["ZipCode"]!
        };

        public static CheckoutData GetRandomCheckoutData() => new()
        {
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            ZipCode = FakerHelper.GetNumericStringRandomValue(5)
        };

        public static CheckoutData CreateCheckoutData(string firstName, string lastName, string zipCode)
        {
            return new CheckoutData()
            {
                FirstName = firstName,
                LastName = lastName,
                ZipCode = zipCode
            };
        }
    }
}