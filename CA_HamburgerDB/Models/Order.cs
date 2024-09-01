using System;
using System.Collections.Generic;

namespace CA_HamburgerDB.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int HamburgerId { get; set; }

    public int ExtraId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Extra Extra { get; set; } = null!;

    public virtual Hamburger Hamburger { get; set; } = null!;
}
