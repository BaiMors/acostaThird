using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class Visit
{
    public int Visitid { get; set; }

    public int Outlet { get; set; }

    public int Project { get; set; }

    public DateOnly Visitdate { get; set; }

    public TimeOnly Visittime { get; set; }

    public int Accepted { get; set; }

    public string Merchcomment { get; set; } = null!;

    public virtual Acceptance AcceptedNavigation { get; set; } = null!;

    public virtual Outlet OutletNavigation { get; set; } = null!;

    public virtual ICollection<ProductReport> ProductReports { get; set; } = new List<ProductReport>();

    public virtual Project ProjectNavigation { get; set; } = null!;
}
