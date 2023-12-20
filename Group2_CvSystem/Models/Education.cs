using System;
using System.Collections.Generic;

namespace Group2_CvSystem.Models;

public partial class Education
{
    public int EducationId { get; set; }

    public string? EducationName { get; set; }

    public virtual ICollection<Cv> Cvs { get; set; } = new List<Cv>();
}
