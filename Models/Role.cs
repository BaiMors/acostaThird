using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class Role
{
    public int Roleid { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
