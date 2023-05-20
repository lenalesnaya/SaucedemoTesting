using Bogus;
using Core.Models;
using Core.Utilites.Configuration;

namespace SaucedemoTests.Models.Utilities
{
    internal class UserBuilder
    {
        static readonly Faker faker = new();

        public static User StandartUser => Configurator.UserByUsername("standard_user")!;
        public static User LockedOutUser => Configurator.UserByUsername("locked_out_user")!;
        public static User ProblemUser => Configurator.UserByUsername("problem_user")!;
        public static User PerformanceGlitchUser => Configurator.UserByUsername("performance_glitch_user")!;

        public static User GetRandomUser() => new()
        {
            Username = faker.Internet.UserName(),
            Password = faker.Internet.Password(10)
        };

        public static User CreateUser(string username, string password)
        {
            return new User()
            {
                Username = username,
                Password = password
            };
        }
    }
}