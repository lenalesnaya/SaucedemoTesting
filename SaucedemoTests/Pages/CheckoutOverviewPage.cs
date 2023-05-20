using Core.BaseEntities;
using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;

namespace SaucedemoTests.Pages
{
    public class CheckoutOverviewPage : SaucedemoPage
    {
        private static readonly string END_POINT =
            Configurator.Configuration.GetSection("Endpoints")["CheckoutOverviewPage"]!;

        private static readonly By FinishButtonBy = By.CssSelector("button[data-test='finish']");

        public Button FinishButton => new(Driver, FinishButtonBy);

        public CheckoutOverviewPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public CheckoutOverviewPage(IWebDriver? driver) : base(driver, false) { }

        protected override void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Test.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return FinishButton.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public CheckoutCompletePage ClickFinishButton()
        {
            FinishButton.Click();
            return new CheckoutCompletePage(Driver);
        }
    }
}