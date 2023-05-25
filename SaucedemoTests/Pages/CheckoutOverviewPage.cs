using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;
using SaucedemoTests.Pages.Abstractions;

namespace SaucedemoTests.Pages
{
    public class CheckoutOverviewPage : SaucedemoPage
    {
        private static readonly By FinishButtonBy = By.CssSelector("button[data-test='finish']");

        public Button FinishButton => new(Driver, FinishButtonBy);

        protected override string EndPoint =>
            Configurator.Configuration.GetSection("Endpoints")["CheckoutOverviewPage"]!;

        public CheckoutOverviewPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public CheckoutOverviewPage(IWebDriver? driver) : base(driver, false) { }

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
            _logger.Info($"Go to {nameof(CheckoutCompletePage)}");

            return new CheckoutCompletePage(Driver);
        }

        public override string ToString() =>
            nameof(CheckoutOverviewPage);
    }
}