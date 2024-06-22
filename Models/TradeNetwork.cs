using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class TradeNetwork
{
    public int Tradeid { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Outlet> Outlets { get; set; } = new List<Outlet>();
}
