using Microsoft.EntityFrameworkCore;
using Purchase.Models;

namespace Purchase.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<SupplierModel> Suppliers { get; set; }
    }
}
