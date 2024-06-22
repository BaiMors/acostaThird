using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string Title { get; set; } = null!;

    public int Project { get; set; }

    public virtual ICollection<ProductReport> ProductReports { get; set; } = new List<ProductReport>();

    public virtual Project ProjectNavigation { get; set; } = null!;
}
