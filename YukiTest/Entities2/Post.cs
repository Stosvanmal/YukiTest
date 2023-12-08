using System;
using System.Collections.Generic;

namespace YukiTest.API.Entities2;

public partial class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;
}
