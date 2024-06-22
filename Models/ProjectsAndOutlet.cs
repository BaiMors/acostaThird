using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class ProjectsAndOutlet
{
    public int Projectid { get; set; }

    public int Outletid { get; set; }

    public virtual Outlet Outlet { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
