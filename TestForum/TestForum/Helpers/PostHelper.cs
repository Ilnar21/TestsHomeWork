using OpenQA.Selenium;

namespace SeleniumTests
{
    public class PostHelper : HelperBase
    {
        public PostHelper(AppManager manager)
            : base(manager)
        {
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
