using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;

namespace SeleniumTests
{
    [TestFixture]
    public class ForumTests : TestBase
    {
        private AccountData user = new AccountData("rayan", "");

        public static IEnumerable<PostData> PostDataFromXmlFile()
        {
            return (List<PostData>) new XmlSerializer(typeof(List<PostData>))
                .Deserialize(new StreamReader(@"posts.xml"));
        }

        [Test]
        public void LoginTest()
        {
            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);

            Assert.IsTrue(app.Post.IsLoggedIn(), "Authorization failed");
        }

        [Test, TestCaseSource("PostDataFromXmlFile")]
        public void CreatePostTest(PostData post)
        {
            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
            app.Navigation.OpenReplyPage();
            app.Post.CreatePost(post);

            Assert.IsTrue(app.Post.IsPostCreatedSuccessfully(post.Message),
                "Post was not created or created text was not found");
        }

        [Test]
        public void EditPostTest()
        {
            string postId = "12339875";
            PostData editedPost = new PostData("Спасибо большое, а передвижения между странами Шенгена нужно предоставлять при подаче документов на визу, верно?");

            app.Navigation.OpenLoginPage();
            app.Auth.Login(user);
            app.Navigation.OpenEditPage(postId);
            app.Post.EditPost(editedPost);

            Assert.IsTrue(app.Post.IsPostEditedSuccessfully(postId, editedPost.Message),
                "Post was not edited or edited text was not found");
        }
    }
}
