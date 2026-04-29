using OpenQA.Selenium;
using System;

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
            FillMessage(post);
            wait.Until(d => d.FindElement(By.Name("post"))).Click();
        }

        public void EditPost(PostData post)
        {
            FillMessage(post);
            wait.Until(d => d.FindElement(By.Name("post"))).Click();
        }

        public string GetPostText(string postId)
        {
            IWebElement post = wait.Until(d => d.FindElement(By.Id("p" + postId)));
            return post.Text;
        }

        public bool IsPostCreatedSuccessfully(string message)
        {
            try
            {
                wait.Until(d => d.Url.Contains("viewtopic.php") && d.PageSource.Contains(message));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsPostEditedSuccessfully(string postId, string message)
        {
            try
            {
                wait.Until(d => d.Url.Contains("viewtopic.php"));
                return GetPostText(postId).Contains(message);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsLoggedIn()
        {
            try
            {
                return IsElementPresent(By.CssSelector("a[href*='mode=logout']"));
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void FillMessage(PostData post)
        {
            IWebElement messageBox = wait.Until(d => d.FindElement(By.Id("message")));
            messageBox.Click();
            messageBox.Clear();
            messageBox.SendKeys(post.Message);
        }
    }
}
