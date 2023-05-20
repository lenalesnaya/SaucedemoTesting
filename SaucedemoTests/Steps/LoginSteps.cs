using Core.BaseEntities;
using OpenQA.Selenium;
using SaucedemoTests.Pages;
using SaucedemoTests.Models.Utilities;

namespace SaucedemoTests.Steps
{
    public class LoginSteps : Step
    {
        public LoginSteps(IWebDriver? driver) : base(driver) { }

        public InventoryPage StandartUserLogin() =>
            new LoginPage(Driver, true).Login(UserBuilder.StandartUser);
    }
}