using Core.BaseEntities;
using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;

namespace SaucedemoTests.Pages
{
    public class InventoryPage : SaucedemoPage
    {
        private static readonly string END_POINT =
            Configurator.Configuration.GetSection("Endpoints")["InventoryPage"]!;

        private static readonly By ProductsTitleBy =
            By.XPath("//span[@class='title' and contains(text(),'Product')]");
        private static readonly By ShoppingCartLinkBy = By.ClassName("shopping_cart_link");
        private static readonly By ShoppingCartBadgeBy = By.ClassName("shopping_cart_badge");
        private static readonly By ProductNameBy =
            By.ClassName("inventory_item_name");
        private static readonly By AddToCartButtonBy =
            By.XPath("//button[contains(@data-test,'add-to-cart')]");
        private static readonly By RemoveButtonBy =
            By.XPath("//button[contains(@data-test,'remove')]");

        public UIElement ProductsTitle => new(Driver, ProductsTitleBy);

        public UIElement ShoppingCartLink => new(Driver, ShoppingCartLinkBy);

        public UIElement ShoppingCartBadge => new(Driver, ShoppingCartBadgeBy);

        public UIElement InventoryItemName => new(Driver, ProductNameBy);

        public Button AddToCartButton => new(Driver, AddToCartButtonBy);

        public Button RemoveButton => new(Driver, RemoveButtonBy);

        public InventoryPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public InventoryPage(IWebDriver? driver) : base(driver, false) { }

        protected override void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Test.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return ShoppingCartLink.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public InventoryPage ClickAddToCartButton()
        {
            AddToCartButton.Click();
            return this;
        }

        public ShoppingCartPage ClickShoppingCartLink()
        {
            ShoppingCartLink.Click();
            return new ShoppingCartPage(Driver);
        }

        public bool CheckRemoveButtonPresented() => RemoveButton.Displayed;


        public bool CheckShoppingCartBadgeIsCorrect(int quantityOfProducts)
        {
            if (!ShoppingCartBadge.Displayed)
                return false;

            return ShoppingCartBadge.Text == quantityOfProducts.ToString();
        }
    }
}