using System;
using System.Collections.Generic;

namespace Group2_CvSystem.Models;

public partial class Competence
{
    public int CompetenceId { get; set; }

    public string? CompetenceName { get; set; }

    public virtual ICollection<Cv> Cvs { get; set; } = new List<Cv>();
}
