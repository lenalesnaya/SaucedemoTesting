using Core.BaseEntities;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SaucedemoTests.Models.Utilities;
using SaucedemoTests.Pages;

namespace SaucedemoTests.Steps
{
    internal class CheckoutSteps : Step
    {
        public CheckoutSteps(IWebDriver? driver) : base(driver) { }

        [AllureStep("Checkout with standart valid checkout data.")]
        public CheckoutCompletePage StandartDataCheckout(InventoryPage inventoryPage) =>
            inventoryPage.
                ClickAddToCartButton().
                ClickShoppingCartLink().
                ClickCheckoutButton().
                Checkout(CheckoutDataBuilder.StandartCheckoutData).
                ClickFinishButton();
    }
}