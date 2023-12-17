using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VVE_Pizza.Models;

namespace VVE_Pizza.Context
{
    public class ApplicationContext: IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
    
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Pizza> Pizzas { get; set; }

    }

}
