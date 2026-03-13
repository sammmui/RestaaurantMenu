using System;
using System.Collections.Generic;

namespace RestaurantMenuDomain.Model;

public partial class User : Entity
{


    public string Name { get; set; } = null!;

    public string? Number { get; set; }
}