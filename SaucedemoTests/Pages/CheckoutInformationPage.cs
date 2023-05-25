using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;
using SaucedemoTests.Models;
using SaucedemoTests.Pages.Abstractions;

namespace SaucedemoTests.Pages
{
    public class CheckoutInformationPage : SaucedemoPage
    {
        private static readonly By FirstNameInputBy = By.CssSelector("input[data-test='firstName']");
        private static readonly By LastNameInputBy = By.CssSelector("input[data-test='lastName']");
        private static readonly By ZipCodeInputBy = By.CssSelector("input[data-test='postalCode']");
        private static readonly By ContinueButtonBy = By.CssSelector("input[data-test='continue']");

        public UIElement FirstNameInput => new(Driver, FirstNameInputBy);

        public UIElement LastNameInput => new(Driver, LastNameInputBy);

        public UIElement ZipCodeInput => new(Driver, ZipCodeInputBy);

        public Button ContinueButton => new(Driver, ContinueButtonBy);

        protected override string EndPoint =>
            Configurator.Configuration.GetSection("Endpoints")["CheckoutInformationPage"]!;

        public CheckoutInformationPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public CheckoutInformationPage(IWebDriver? driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            try
            {
                return FirstNameInput.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public CheckoutInformationPage SetFirstName(string firstName)
        {
            FirstNameInput.SendKeys(firstName);
            return this;
        }

        public CheckoutInformationPage SetLastName(string lastName)
        {
            LastNameInput.SendKeys(lastName);
            return this;
        }

        public CheckoutInformationPage SetZipCode(string zipCode)
        {
            ZipCodeInput.SendKeys(zipCode);
            return this;
        }

        public CheckoutInformationPage ClickContinueButton()
        {
            ContinueButton.Click();
            return this;
        }

        public CheckoutOverviewPage Checkout(CheckoutData checkoutData)
        {
            TryToCheckout(checkoutData);
            _logger.Info($"Go to {nameof(CheckoutOverviewPage)}");

            return new CheckoutOverviewPage(Driver);
        }

        public CheckoutInformationPage TryToCheckout(CheckoutData checkoutData) =>
            SetFirstName(checkoutData.FirstName).
                SetLastName(checkoutData.LastName).
                SetZipCode(checkoutData.ZipCode).
                ClickContinueButton();

        public override string ToString() =>
            nameof(CheckoutInformationPage);
    }
}