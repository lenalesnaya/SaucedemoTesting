using Allure.Commons;
using Core.Utilites.Configuration;
using NLog;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Core.BaseEntities
{
    [Parallelizable(ParallelScope.All)]
    [AllureNUnit]
    public abstract class Test
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        private AllureLifecycle _allure;

        [ThreadStatic] protected static IWebDriver? Driver;
        protected WaitService? WaitService;

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
            _allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver!).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver?.Quit();
        }
    }
}