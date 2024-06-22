using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class Project
{
    public int Projectid { get; set; }

    public string Title { get; set; } = null!;

    public int Numofvisitsperweek { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
