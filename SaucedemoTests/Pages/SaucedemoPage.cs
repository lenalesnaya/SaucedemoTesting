using Core.BaseEntities;
using Core.Wrappers;
using OpenQA.Selenium;

namespace SaucedemoTests.Pages
{
    public abstract class SaucedemoPage : Page
    {
        protected const string InputLocatorTemplate = "input[data-test='{0}']";

        protected static readonly By ErrorMessageBy = By.CssSelector("h3[data-test='error']");

        public UIElement ErrorMessage => new(Driver, ErrorMessageBy);

        public SaucedemoPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public SaucedemoPage(IWebDriver? driver) : base(driver, false) { }

        public bool CheckErrorMassagePresented() => ErrorMessage.Displayed;

        public bool CheckErrorMassageIsCorrect(string message) => ErrorMessage.Text.Equals(message);

        protected static By GetInputLocator(string inputLocator) =>
            By.CssSelector(string.Format(InputLocatorTemplate, inputLocator));
    }
}