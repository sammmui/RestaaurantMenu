using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantMenuDomain.Model;

namespace RestaurantMenuInfrastructure.Models
{
    public class IdentityContext : IdentityDbContext<Account>
    {
        
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }
    }
}