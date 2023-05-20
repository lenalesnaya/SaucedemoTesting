using OpenQA.Selenium;

namespace Core.Wrappers
{
    public class TableRow
    {
        private UIElement _uiElement;
        
        public TableRow(IWebDriver? driver, By @by)
        {
            _uiElement = new UIElement(driver, @by);
        }

        public TableRow(IWebDriver? driver, IWebElement webElement)
        {
            _uiElement = new UIElement(driver, webElement);
        }
    }
}