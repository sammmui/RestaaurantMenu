using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity; 

namespace RestaurantMenuDomain.Model
{
    
    public class Account : IdentityUser
    {
      
        public int Year { get; set; }

      
    }
}