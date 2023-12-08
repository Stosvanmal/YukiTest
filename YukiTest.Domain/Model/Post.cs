using YukiTest.Domain.Interfaces;

namespace YukiTest.Domain.Model
{
    public class Post:IEntity
    {
        protected Post() { }
        public Post(string title, string description,string content, Author author)
        {
            SetTitle(title);
            SetDescritpion(description);
            SetAuthor(author);
            SetContent(content);
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int AuthorId { get; private set; }
        public virtual Author Author { get; private set; }
        public string Content { get; private set; }
        public void SetContent(string content)
        {
            Content = content;
        }
        public void SetTitle(string title)
        {
            Title = title;
        }
        public void SetDescritpion(string descritpion)
        {
            Description = descritpion;
        }
        public void SetAuthor(Author author)
        {
            Author = author;
            AuthorId = author.Id;
        }
        public static Post CreatePost(string title, string description,string content, Author author)
        {
            return new Post(title,description,content, author);
        }
    }
}
