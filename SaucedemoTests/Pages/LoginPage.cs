using Core.Models;
using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;
using SaucedemoTests.Pages.Abstractions;

namespace SaucedemoTests.Pages
{
    public class LoginPage : SaucedemoPage
    {
        private static readonly By UserNameInputBy = By.CssSelector("input[data-test='username']");
        private static readonly By PasswordInputBy = By.CssSelector("input[data-test='password']");
        private static readonly By LoginButtonBy = By.CssSelector("input[data-test='login-button']");

        public const string LockedOutUserErrorMessage =
            "Epic sadface: Sorry, this user has been locked out.";
        public const string NonExistentUserErrorMessage =
            "Epic sadface: Username and password do not match any user in this service";

        public UIElement UserNameInput => new(Driver, UserNameInputBy);

        public UIElement PasswordInput => new(Driver, PasswordInputBy);

        public Button LoginButton => new(Driver, LoginButtonBy);

        protected override string EndPoint =>
            Configurator.Configuration.GetSection("Endpoints")["LoginPage"]!;

        public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public LoginPage(IWebDriver? driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            try
            {
                return LoginButton.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public LoginPage SetUserName(string userName)
        {
            UserNameInput.SendKeys(userName);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            PasswordInput.SendKeys(password);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            LoginButton.Click();
            return this;
        }

        public InventoryPage Login(User user)
        {
            TryToLogin(user);
            return new InventoryPage(Driver);
        }

        public LoginPage TryToLogin(User user) =>
            SetUserName(user.Username).
                SetPassword(user.Password).
                ClickLoginButton();
    }
}