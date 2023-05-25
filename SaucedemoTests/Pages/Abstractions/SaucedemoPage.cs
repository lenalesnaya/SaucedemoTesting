using Core.BaseEntities;
using Core.Wrappers;
using OpenQA.Selenium;

namespace SaucedemoTests.Pages.Abstractions
{
    public abstract class SaucedemoPage : Page
    {
        protected static readonly By ErrorMessageBy = By.CssSelector("h3[data-test='error']");
        protected abstract string EndPoint { get; }

        public UIElement ErrorMessage => new(Driver, ErrorMessageBy);

        public SaucedemoPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public SaucedemoPage(IWebDriver? driver) : base(driver, false) { }

        protected override void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Test.BaseUrl + EndPoint);
            _logger.Info($"Go to {this}");
        }

        public bool CheckErrorMassagePresented() => ErrorMessage.Displayed;

        public bool CheckErrorMassageIsCorrect(string message) => ErrorMessage.Text.Equals(message);
    }
}