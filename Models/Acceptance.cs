using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class Acceptance
{
    public int Acceptanceid { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
