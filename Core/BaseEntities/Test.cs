using Core.Utilites.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.BaseEntities
{
    public abstract class Test
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        [ThreadStatic] protected static IWebDriver? Driver;
        protected WaitService? WaitService;

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }
    }
}