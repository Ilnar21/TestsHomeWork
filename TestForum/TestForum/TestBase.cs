using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        protected WebDriverWait wait;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            baseURL = "https://forum.awd.ru/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl("https://forum.awd.ru/ucp.php?mode=login");
            wait.Until(d => d.FindElement(By.Id("username")).Displayed);
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

        public void OpenReplyPage()
        {
            driver.Navigate().GoToUrl("https://forum.awd.ru/posting.php?mode=reply&f=561&t=410500");
            wait.Until(d => d.FindElement(By.Id("message")).Displayed);
        }

        public void CreatePost(PostData post)
        {
            IWebElement messageBox = wait.Until(d => d.FindElement(By.Id("message")));
            messageBox.Click();
            messageBox.Clear();
            messageBox.SendKeys(post.Message);

            wait.Until(d => d.FindElement(By.Name("post"))).Click();
        }
    }
}