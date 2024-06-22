using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class ProjectsAndEmployee
{
    public int Employeeid { get; set; }

    public int Projectid { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
