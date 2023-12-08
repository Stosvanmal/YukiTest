using System;
using System.Collections.Generic;

namespace YukiTest.API.Entities2;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Surname { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
