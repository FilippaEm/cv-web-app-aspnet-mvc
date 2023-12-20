using System;
using System.Collections.Generic;

namespace Group2_CvSystem.Models;

public partial class Project
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? ImageProject { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
