namespace YukiTest.Presentation.Response
{
    public class PostResponse
    {
        public string Description { get; set;}
        public int Id { get; set;}
        public string Title { get; set; }
        public string Content { get; set; }
        public AuthorResponse Author { get; set; }
    }
}
