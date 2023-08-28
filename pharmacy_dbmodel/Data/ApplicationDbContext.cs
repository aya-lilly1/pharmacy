using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pharmacy_dbmodel.Models;
using pharmacy_DbModel.Models;

namespace pharmacy_DbModel.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Durg> Durgs { get; set; }
        public DbSet<TempOrder> TempOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}