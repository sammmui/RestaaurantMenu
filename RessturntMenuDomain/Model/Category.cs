using System;
using System.Collections.Generic;

namespace RestaurantMenuDomain.Model;

public partial class Category : Entity
{


    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}