using NUnit.Framework;

namespace SeleniumTests
{
    [TestFixture]
    public class ForumTests : TestBase
    {
        [Test]
        public void LoginTest()
        {
            AccountData user = new AccountData("rayan", "");
            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
        }

        [Test]
        public void CreatePostTest()
        {
            AccountData user = new AccountData("rayan", "");
            PostData post = new PostData("Добрый день, подскажите пожалуйста, нужно ли предоставлять билеты по передвижению по городам Италии?");
            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
            app.Navigation.OpenReplyPage();
            app.Post.CreatePost(post);
        }
    }
}
