using Core.BaseEntities;
using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;
using SaucedemoTests.Models;
using System.Reflection.Emit;

namespace SaucedemoTests.Pages
{
    public class CheckoutInformationPage : SaucedemoPage
    {
        private static readonly string END_POINT =
            Configurator.Configuration.GetSection("Endpoints")["CheckoutInformationPage"]!;

        private static readonly By FirstNameInputBy = GetInputLocator("firstName");
        private static readonly By LastNameInputBy = GetInputLocator("lastName");
        private static readonly By ZipCodeInputBy = GetInputLocator("postalCode");
        private static readonly By ContinueButtonBy = GetInputLocator("continue");

        public UIElement FirstNameInput => new(Driver, FirstNameInputBy);

        public UIElement LastNameInput => new(Driver, LastNameInputBy);

        public UIElement ZipCodeInput => new(Driver, ZipCodeInputBy);

        public Button ContinueButton => new(Driver, ContinueButtonBy);

        public CheckoutInformationPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public CheckoutInformationPage(IWebDriver? driver) : base(driver, false) { }

        protected override void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Test.BaseUrl + END_POINT);
        }

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
            return new CheckoutOverviewPage(Driver);
        }

        public CheckoutInformationPage TryToCheckout(CheckoutData checkoutData)
        {
            return SetFirstName(checkoutData.FirstName).
                SetLastName(checkoutData.LastName).
                SetZipCode(checkoutData.ZipCode).
                ClickContinueButton();
        }
    }
}