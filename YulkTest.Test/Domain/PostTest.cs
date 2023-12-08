using AutoFixture.Xunit2;
using YukiTest.Domain.Model;

namespace YulkTest.Test.Domain
{
    public class PostTest
    {
        public PostTest() 
        {
            
        }
        private static Post GetIPostDefaul()
        {
            string defaultText = "test";
            Author author = Author.Create(defaultText, defaultText);
            return Post.CreatePost(defaultText, defaultText, defaultText, author);
        }
        [Theory,AutoData]
        public void Creation_OK(string title, string content,string description, string name, string surname)
        {
            
            Author author = Author.Create(name, surname);
            Post post = Post.CreatePost(title,description,content,author);

            Assert.Equal(title, post.Title);
            Assert.Equal(description, post.Description);
            Assert.Equal(content, post.Content);
            Assert.Equal(name, post.Author.Name);
            Assert.Equal(surname, post.Author.Surname);            
        }
        [Theory,AutoData]
        public void SetDescription_Ok(string text)
        {
            var post = GetIPostDefaul();

            post.SetDescritpion(text);

            Assert.Equal(text, post.Description);   
        }
        [Theory, AutoData]
        public void SetContent_Ok(string text)
        {
            var post = GetIPostDefaul();

            post.SetContent(text);

            Assert.Equal(text, post.Content);
        }
    }
}
