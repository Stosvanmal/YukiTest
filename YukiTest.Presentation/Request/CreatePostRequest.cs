using System.ComponentModel.DataAnnotations;

namespace YukiTest.Presentation.Request
{
    public class CreatePostRequest
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Content { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public CreateAuthorRequest Author { get; set; }
    }
}
