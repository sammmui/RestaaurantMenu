using System;
using System.Collections.Generic;

namespace RestaurantMenuDomain.Model;

public partial class Discount : Entity
{

    public string Description { get; set; } = null!;

    public DateTime Period { get; set; }
}