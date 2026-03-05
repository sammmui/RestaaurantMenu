using System;
using System.Collections.Generic;

namespace RestaurantMenuDomain.Model;

public partial class Review: Entity
{
   

    public DateTime Data { get; set; }

    public decimal Mark { get; set; }

    public string? Comment { get; set; }

    public int Productsid { get; set; }

    public virtual Product Products { get; set; } = null!;
}
