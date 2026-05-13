using NUnit.Framework;

namespace SeleniumTests
{
    public class AuthBase : TestBase
    {
        protected AccountData user;

        [SetUp]
        public void SetupAuth()
        {
            user = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Login(user);
        }
    }
}
