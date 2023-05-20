using Core.BaseEntities;
using Core.Models;
using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;
using SaucedemoTests.Models;

namespace SaucedemoTests.Pages
{
    public class ShoppingCartPage : SaucedemoPage
    {
        private static readonly string END_POINT =
            Configurator.Configuration.GetSection("Endpoints")["ShoppingCartPage"]!;

        private static readonly By YourCartTitleBy =
            By.XPath("//span[@class='title' and contains(text(),'Cart')]");
        private static readonly By CheckoutButtonBy = By.CssSelector("button[data-test='checkout']");
        private static readonly By InventoryItemNameBy = By.ClassName("inventory_item_name");

        public const string FirstNameErrorMessage = "Error: First Name is required";
        public const string LastNameErrorMessage = "Error: Last Name is required";
        public const string ZipCodeErrorMessage = "Error: Postal Code is required";

        public UIElement YourCartTitle => new(Driver, YourCartTitleBy);
        public Button CheckoutButton => new(Driver, CheckoutButtonBy);
        public UIElement InventoryItemName => new(Driver, InventoryItemNameBy);

        public ShoppingCartPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public ShoppingCartPage(IWebDriver? driver) : base(driver, false) { }

        protected override void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Test.BaseUrl + END_POINT);
        }

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
            return new CheckoutInformationPage(Driver);
        }
    }
}