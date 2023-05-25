using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;
using SaucedemoTests.Pages.Abstractions;

namespace SaucedemoTests.Pages
{
    public class ShoppingCartPage : SaucedemoPage
    {
        private static readonly By YourCartTitleBy =
            By.XPath("//span[@class='title' and contains(text(),'Cart')]");
        private static readonly By CheckoutButtonBy = By.CssSelector("button[data-test='checkout']");
        private static readonly By InventoryItemNameBy = By.ClassName("inventory_item_name");

        public const string RequiredFieldErrorTemplate = "Error: {0} is required";
        public readonly string FirstNameFieldName =
            string.Format(RequiredFieldErrorTemplate, "First Name");
        public readonly string LastNameFieldName =
            string.Format(RequiredFieldErrorTemplate, "Last Name");
        public readonly string ZipCodeFieldName =
            string.Format(RequiredFieldErrorTemplate, "Postal Code");

        public UIElement YourCartTitle => new(Driver, YourCartTitleBy);
        public Button CheckoutButton => new(Driver, CheckoutButtonBy);
        public UIElement InventoryItemName => new(Driver, InventoryItemNameBy);

        protected override string EndPoint =>
            Configurator.Configuration.GetSection("Endpoints")["ShoppingCartPage"]!;

        public ShoppingCartPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public ShoppingCartPage(IWebDriver? driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            try
            {
                return CheckoutButton.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public CheckoutInformationPage ClickCheckoutButton()
        {
            CheckoutButton.Click();
            _logger.Info($"Go to {nameof(CheckoutInformationPage)}");

            return new CheckoutInformationPage(Driver);
        }

        public override string ToString() =>
            nameof(ShoppingCartPage);
    }
}