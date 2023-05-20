using OpenQA.Selenium;

namespace Core.BaseEntities
{
    public class Step
    {
        [ThreadStatic] protected static IWebDriver? Driver;

        public Step(IWebDriver? driver)
        {
            Driver = driver;
        }
    }
}