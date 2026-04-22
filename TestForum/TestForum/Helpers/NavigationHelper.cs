using OpenQA.Selenium;

namespace SeleniumTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(AppManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "ucp.php?mode=login");
            wait.Until(d => d.FindElement(By.Id("username")).Displayed);
        }

        public void OpenReplyPage()
        {
            driver.Navigate().GoToUrl(baseURL + "posting.php?mode=reply&f=561&t=410500");
            wait.Until(d => d.FindElement(By.Id("message")).Displayed);
        }
    }
}
