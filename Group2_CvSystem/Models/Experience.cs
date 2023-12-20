using System;
using System.Collections.Generic;

namespace Group2_CvSystem.Models;

public partial class Experience
{
    public int ExperienceId { get; set; }

    public string? ExperienceName { get; set; }

    public string? Description { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual ICollection<Cv> Cvs { get; set; } = new List<Cv>();
}
