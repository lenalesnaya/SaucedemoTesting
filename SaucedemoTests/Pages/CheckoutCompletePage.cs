using Core.BaseEntities;
using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;

namespace SaucedemoTests.Pages
{
    public class CheckoutCompletePage : SaucedemoPage
    {
        private static readonly string END_POINT =
            Configurator.Configuration.GetSection("Endpoints")["CheckoutCompletePage"]!;

        private static readonly By CompleteHeaderBy = By.ClassName("complete-header");
        private static readonly By BackHomeButtonBy =
            By.CssSelector("button[data-test='back-to-products']");

        public const string OrderConfirmationInscription = "Thank you for your order!";

        public UIElement CompleteHeader => new(Driver, CompleteHeaderBy);

        public Button BackHomeButton => new(Driver, BackHomeButtonBy);

        public CheckoutCompletePage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public CheckoutCompletePage(IWebDriver? driver) : base(driver, false) { }

        protected override void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Test.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return CompleteHeader.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public InventoryPage ClickBackHomeButton()
        {
            BackHomeButton.Click();
            return new InventoryPage(Driver);
        }

        public bool CheckConfirmationMassagePresented() => CompleteHeader.Displayed;

        public bool CheckConfirmationMassageIsCorrect(string message) =>
            CompleteHeader.Text.Equals(message);
    }
}