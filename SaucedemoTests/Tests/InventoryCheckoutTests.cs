﻿using Allure.Commons;
using Core.BaseEntities;
using NUnit.Allure.Attributes;
using SaucedemoTests.Pages;
using SaucedemoTests.Steps;

namespace SaucedemoTests.Tests
{
    [TestFixture]
    internal class InventoryCheckoutTests : Test
    {
        private InventoryPage _inventoryPage;

        [SetUp]
        public void LoginSetup()
        {
            _inventoryPage = new LoginSteps(Driver).StandartUserLogin();
        }

        [Test, Category("Positive"), Description("After adding to cart inventory page check.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("StandartUser")]
        [AllureSuite("InventoryCheckoutTests")]
        [AllureSubSuite("GUI")]
        [AllureIssue("not yet available")]
        [AllureTms("not yet available")]
        //[AllureTag("Smoke")]
        //[AllureLink("")]
        [SmokeTest]
        public void AddToCart_InventoryPageCheck()
        {
            _inventoryPage.ClickAddToCartButton();
            Assert.Multiple(() =>
            {
                Assert.That(_inventoryPage.CheckRemoveButtonPresented());
                Assert.That(_inventoryPage.CheckShoppingCartBadgeIsCorrect(1));
            });
        }

        [Test, Category("Positive"), Description("After adding to cart shopping cart page check.")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureOwner("StandartUser")]
        [AllureSuite("InventoryCheckoutTests")]
        [AllureSubSuite("GUI")]
        [AllureIssue("not yet available")]
        [AllureTms("not yet available")]
        //[AllureTag("Smoke")]
        //[AllureLink("")]
        [SmokeTest]
        public void AddToCart_ShoppingCartCheck()
        {
            var inventoryItemName = _inventoryPage.InventoryItemName.Text;
            var shoppingCartPage = _inventoryPage.ClickAddToCartButton().ClickShoppingCartLink();

            Assert.Multiple(() =>
            {
                Assert.That(shoppingCartPage.IsPageOpened());
                Assert.That(shoppingCartPage.InventoryItemName.Text, Is.EqualTo(inventoryItemName));
            });
        }

        [Test, Category("Positive"), Description("Checkout of an inventory item check with standart valid checkout data.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("StandartUser")]
        [AllureSuite("InventoryCheckoutTests")]
        [AllureSubSuite("GUI")]
        [AllureIssue("not yet available")]
        [AllureTms("not yet available")]
        //[AllureTag("Smoke")]
        //[AllureLink("")]
        [SmokeTest]
        public void CheckoutAnInventoryItem_WithValidCheckoutData()
        {
            var checkoutCompletePage = new CheckoutSteps(Driver).StandartDataCheckout(_inventoryPage);
            Assert.Multiple(() =>
            {
                Assert.That(checkoutCompletePage.IsPageOpened());
                Assert.That(checkoutCompletePage.CheckConfirmationMassagePresented());
                Assert.That(checkoutCompletePage.CheckConfirmationMassageIsCorrect(
                    CheckoutCompletePage.OrderConfirmationInscription));
            });
        }
    }
}