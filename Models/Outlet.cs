using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class Outlet
{
    public int Outletid { get; set; }

    public string Address { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int TradeNetworks { get; set; }

    public virtual TradeNetwork TradeNetworksNavigation { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
