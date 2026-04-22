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
            wait.Until(d => d.FindElement(By.Id("username"))).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(user.Username);

            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(user.Password);

            driver.FindElement(By.Name("login")).Click();
            wait.Until(d => d.Url.Contains("forum.awd.ru") && !d.Url.Contains("mode=login"));
        }
    }
}
