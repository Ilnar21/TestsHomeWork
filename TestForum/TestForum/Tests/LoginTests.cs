using NUnit.Framework;

namespace SeleniumTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            app.Auth.Logout();
            app.Auth.Login(new AccountData(Settings.Login, Settings.Password));

            Assert.IsTrue(app.Auth.IsLoggedIn(Settings.Login), "Authorization with valid data failed");
        }

        [Test]
        public void LoginWithInvalidData()
        {
            app.Auth.Logout();
            app.Auth.Login(new AccountData("invalid-user", "invalid-password"));

            Assert.IsFalse(app.Auth.IsLoggedIn(), "Authorization with invalid data should not be successful");
        }
    }
}
