using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class HelperBase
    {
        protected AppManager manager;
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected bool acceptNextAlert = true;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
