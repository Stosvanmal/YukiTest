using System.ComponentModel.DataAnnotations;

namespace YukiTest.Presentation.Request
{
    public class CreateAuthorRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
    }
}
