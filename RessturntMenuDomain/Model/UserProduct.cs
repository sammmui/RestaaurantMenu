using System;
using System.Collections.Generic;

namespace RestaurantMenuDomain.Model;

public partial class UserProduct : Entity
{
    public int Productsid { get; set; }

    public int Usersid { get; set; }

    public virtual Product Products { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}