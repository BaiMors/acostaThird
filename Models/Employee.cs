using System;
using System.Collections.Generic;

namespace Acosta.Models;

public partial class Employee
{
    public int Employeesid { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Role { get; set; }

    public string Password { get; set; } = null!;

    public virtual Role RoleNavigation { get; set; } = null!;
}
