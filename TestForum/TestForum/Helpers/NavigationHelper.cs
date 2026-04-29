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
            wait.Until(d => IsElementPresent(By.Id("username")) || IsElementPresent(By.CssSelector("a[href*='mode=logout']")));
        }

        public void OpenReplyPage()
        {
            driver.Navigate().GoToUrl(baseURL + "posting.php?mode=reply&f=561&t=410500");
            wait.Until(d => d.FindElement(By.Id("message")).Displayed);
        }

        public void OpenEditPage(string postId)
        {
            driver.Navigate().GoToUrl(baseURL + "posting.php?mode=edit&f=561&p=" + postId);
            wait.Until(d => d.FindElement(By.Id("message")).Displayed);
        }

        public void OpenPostPage(string postId)
        {
            driver.Navigate().GoToUrl(baseURL + "viewtopic.php?f=561&t=410500&p=" + postId + "#p" + postId);
            wait.Until(d => IsElementPresent(By.Id("p" + postId)));
        }
    }
}
