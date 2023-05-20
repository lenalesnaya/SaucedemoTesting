using Core.BaseEntities;
using OpenQA.Selenium;
using SaucedemoTests.Models.Utilities;
using SaucedemoTests.Pages;

namespace SaucedemoTests.Steps
{
    internal class CheckoutSteps : Step
    {
        public CheckoutSteps(IWebDriver? driver) : base(driver) { }

        public CheckoutCompletePage StandartDataCheckout(InventoryPage inventoryPage)
        {
            return inventoryPage.
                ClickAddToCartButton().
                ClickShoppingCartLink().
                ClickCheckoutButton().
                Checkout(CheckoutDataBuilder.StandartCheckoutData).
                ClickFinishButton();
        }
    }
}