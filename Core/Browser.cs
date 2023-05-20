using Core.Utilites.Configuration;
using OpenQA.Selenium;

namespace Core
{
    public class Browser
    {
        private IWebDriver? _webDriver;
        
        public Browser()
        {
            Driver = Configurator.BrowserType.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => Driver
            };

            Driver?.Manage().Window.Maximize();
            Driver?.Manage().Cookies.DeleteAllCookies();
            if (Driver != null) Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
        
        public IWebDriver? Driver { get; set; }
    }
}