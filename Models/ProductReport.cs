using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class ProductReport
{
    public int Productreportid { get; set; }

    public int Product { get; set; }

    public int Price { get; set; }

    public int Pricetothecard { get; set; }

    public int Actualbalance { get; set; }

    public int Virtualbalance { get; set; }

    public int Visit { get; set; }

    public virtual Product ProductNavigation { get; set; } = null!;

    public virtual Visit VisitNavigation { get; set; } = null!;
}
