using Core.BaseEntities;
using OpenQA.Selenium;
using SaucedemoTests.Pages;
using SaucedemoTests.Models.Utilities;
using NUnit.Allure.Attributes;

namespace SaucedemoTests.Steps
{
    public class LoginSteps : Step
    {
        public LoginSteps(IWebDriver? driver) : base(driver) { }

        [AllureStep("Login with standart valid login data.")]
        public InventoryPage StandartUserLogin() =>
            new LoginPage(Driver, true).Login(UserBuilder.StandartUser);
    }
}