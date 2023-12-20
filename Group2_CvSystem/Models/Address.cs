using System;
using System.Collections.Generic;

namespace Group2_CvSystem.Models;

public partial class Address
{
    public int AdressId { get; set; }

    public string? AdressName { get; set; }

    public string? AddressNumber { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressPostcode { get; set; }

    public string? UserId { get; set; }

    public virtual User? User { get; set; }
}
