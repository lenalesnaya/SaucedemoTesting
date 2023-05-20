using Core.BaseEntities;
using Core.Models;
using Core.Utilites.Configuration;
using Core.Wrappers;
using OpenQA.Selenium;

namespace SaucedemoTests.Pages
{
    public class LoginPage : SaucedemoPage
    {
        private static readonly string END_POINT =
            Configurator.Configuration.GetSection("Endpoints")["LoginPage"]!;

        private static readonly By UserNameInputBy = GetInputLocator("username");
        private static readonly By PasswordInputBy = GetInputLocator("password");
        private static readonly By LoginButtonBy = GetInputLocator("login-button");


        public const string LockedOutUserErrorMessage =
            "Epic sadface: Sorry, this user has been locked out.";
        public const string NonExistentUserErrorMessage =
            "Epic sadface: Username and password do not match any user in this service";

        public UIElement UserNameInput => new(Driver, UserNameInputBy);

        public UIElement PasswordInput => new(Driver, PasswordInputBy);

        public Button LoginButton => new(Driver, LoginButtonBy);

        public LoginPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public LoginPage(IWebDriver? driver) : base(driver, false) { }

        protected override void OpenPage()
        {
            Driver!.Navigate().GoToUrl(Test.BaseUrl + END_POINT);
        }

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

        public LoginPage TryToLogin(User user)
        {
            return SetUserName(user.Username).SetPassword(user.Password).ClickLoginButton();
        }
    }
}