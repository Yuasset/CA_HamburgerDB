using System;
using System.Collections.Generic;

namespace CA_HamburgerDB.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
