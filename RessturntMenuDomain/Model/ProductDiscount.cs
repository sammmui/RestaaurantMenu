using System;
using System.Collections.Generic;

namespace RestaurantMenuDomain.Model;

public partial class ProductDiscount : Entity
{
    public int Discountsid { get; set; }

    public int Productsid { get; set; }

    public virtual Discount Discounts { get; set; } = null!;

    public virtual Product Products { get; set; } = null!;
}