﻿using System;
using System.Collections.Generic;

namespace CA_HamburgerDB.Models;

public partial class Hamburger
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
