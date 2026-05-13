using System;
using OpenQA.Selenium;

namespace SeleniumTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager)
            : base(manager)
        {
        }

        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }
                Logout();
            }

            manager.Navigation.OpenLoginPage();

            wait.Until(d => d.FindElement(By.Id("username"))).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(user.Username);

            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(user.Password);

            driver.FindElement(By.Name("login")).Click();

            wait.Until(d => IsLoggedIn() || IsLoginErrorPresent());
        }

        public void Logout()
        {
            if (!IsLoggedIn())
            {
                return;
            }

            driver.FindElement(By.CssSelector("a[href*='mode=logout']")).Click();
            wait.Until(d => IsElementPresent(By.Id("username")) || !IsLoggedIn());
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("a[href*='mode=logout']"));
        }

        public bool IsLoggedIn(string username)
        {
            if (!IsLoggedIn())
            {
                return false;
            }

            foreach (IWebElement element in driver.FindElements(By.CssSelector("a[href*='memberlist.php']")))
            {
                if (element.Text.Trim().Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsLoginErrorPresent()
        {
            return IsElementPresent(By.CssSelector(".error"))
                || IsElementPresent(By.CssSelector(".errorbox"))
                || driver.PageSource.Contains("incorrect")
                || driver.PageSource.Contains("Invalid");
        }
    }
}
