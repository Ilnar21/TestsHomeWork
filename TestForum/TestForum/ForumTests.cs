using NUnit.Framework;

namespace SeleniumTests
{
    [TestFixture]
    public class ForumTests : TestBase
    {
        [Test]
        public void LoginTest()
        {
            AccountData user = new AccountData("", "");
            OpenLoginPage();
            Login(user);
        }

        [Test]
        public void CreatePostTest()
        {
            AccountData user = new AccountData("", "");
            PostData post = new PostData("Добрый день, подскажите пожалуйста, нужно ли предоставлять билеты по передвижению по городам Италии?");
            OpenLoginPage();
            Login(user);
            OpenReplyPage();
            CreatePost(post);
        }
    }
}