using System;
using System.Collections.Generic;

namespace Group2_CvSystem.Models;

public partial class Cv
{
    public int CvId { get; set; }

    public string? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<Competence> Competences { get; set; } = new List<Competence>();

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
}
