using NLog;
using OpenQA.Selenium;

namespace Core.BaseEntities
{
    public abstract class Page
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        protected static int WAIT_FOR_PAGE_LOADING_TIME = 60;
        [ThreadStatic] protected static IWebDriver? Driver;

        public Page(IWebDriver? driver, bool openPageByUrl)
        {
            Driver = driver;

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        protected abstract void OpenPage();
        public abstract bool IsPageOpened();
    }
}