using Core.BaseEntities;
using Core.Models;
using SaucedemoTests.Pages;
using SaucedemoTests.TestValues;

namespace SaucedemoTests.Tests
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class LoginTests : Test
    {
        [Test, Category("Positive"), Description("Go to login page check.")]
        [SmokeTest]
        public void GoTo_LoginPage()
        {
            var loginPage = new LoginPage(Driver, true);
            Assert.That(loginPage.IsPageOpened(), Is.True);
        }

        [Test, Category("Positive"), Description("Login with valid user credentials check.")]
        [TestCaseSource(typeof(LoginValidValues), nameof(LoginValidValues.TestCases))]
        [SmokeTest]
        public void Login_WithValidUserCredentials(User user)
        {
            var inventoryPage = new LoginPage(Driver, true).Login(user);
            Assert.Multiple(() =>
            {
                Assert.That(inventoryPage.IsPageOpened(), Is.True);
                Assert.That(inventoryPage.ProductsTitle.Displayed);
            });
        }

        [Test, Category("Negative"), Description("Login with locked out user credentials check.")]
        [TestCaseSource(typeof(LoginLockedOutUserValues), nameof(LoginLockedOutUserValues.TestCases))]
        [Regression]
        public void Login_WithLockedOutUserCredentials(User user)
        {
            var loginPage = new LoginPage(Driver, true).TryToLogin(user);
            Assert.Multiple(() =>
            {
                Assert.That(loginPage.CheckErrorMassagePresented());
                Assert.That(loginPage.CheckErrorMassageIsCorrect(
                    LoginPage.LockedOutUserErrorMessage));
            });
        }

        [Test, Category("Negative"), Description("Login with invalid credentials check.")]
        [TestCaseSource(typeof(LoginNonExistentUserValues), nameof(LoginNonExistentUserValues.TestCases))]
        [Regression]
        public void Login_WithInvalidCredentials(User user)
        {
            var loginPage = new LoginPage(Driver, true).TryToLogin(user);
            Assert.Multiple(() =>
            {
                Assert.That(loginPage.CheckErrorMassagePresented());
                Assert.That(loginPage.CheckErrorMassageIsCorrect(
                    LoginPage.NonExistentUserErrorMessage));
            });
        }
    }
}