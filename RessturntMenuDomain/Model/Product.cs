using System;
using System.Collections.Generic;

namespace RestaurantMenuDomain.Model;

public partial class Product: Entity
{
  
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? Categoriesid { get; set; }

    public virtual Category? Categories { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
