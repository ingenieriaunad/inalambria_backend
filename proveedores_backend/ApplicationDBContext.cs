using Microsoft.EntityFrameworkCore;
using proveedores_backend.Models;
namespace proveedores_backend
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options){ }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Provider> providers = new();
            providers.Add(
                new Provider() 
                { 
                    IdProvider = Guid.NewGuid(), 
                    Identification = "123456789", 
                    Name = "Proveedor 1", 
                    Phone = "123456789", 
                    Email = "proveedor1@inalambria.com" 
                }
            );
            providers.Add(
                new Provider()
                { 
                    IdProvider = Guid.NewGuid(), 
                    Identification = "987654321", 
                    Name = "Proveedor 2",
                    Phone = "987654321", 
                    Email = "proveedor2@inalambria.com" 
                }
            );
            //mensaje de error identificacion unica
            modelBuilder.Entity<Provider>(proveedor=>{
                proveedor.HasKey(p=>p.IdProvider);
                proveedor.Property(p=>p.IdProvider)
                         .HasDefaultValueSql("NEWID()");
                proveedor.Property(p=>p.Identification)
                         .IsRequired()
                         .HasMaxLength(15);
                proveedor.HasIndex(p=>p.Identification)
                         .IsUnique();        
                proveedor.Property(p=>p.Name)
                         .IsRequired()
                         .HasMaxLength(250);
                proveedor.Property(p=>p.Phone)
                         .IsRequired()
                         .HasMaxLength(15);
                proveedor.Property(p=>p.Email)
                         .IsRequired()
                         .HasMaxLength(250); 
                proveedor.HasData(providers);
            });

            List<Product> products = new List<Product>();
            products.Add(
                new Product()
                {
                    IdProduct = Guid.NewGuid(),
                    Name = "Producto 1",
                    Price = 1000,
                    Stock = 10,
                    IdProvider = providers[0].IdProvider
                }
            );
            products.Add(
                new Product()
                {
                    IdProduct = Guid.NewGuid(),
                    Name = "Producto 2",
                    Price = 2000,
                    Stock = 20,
                    IdProvider = providers[1].IdProvider
                }
            );
            modelBuilder.Entity<Product>(producto=>{
                producto.HasKey(p=>p.IdProduct);
                producto.Property(p=>p.IdProduct)
                        .HasDefaultValueSql("NEWID()");
                producto.Property(p=>p.Name)
                        .IsRequired()
                        .HasMaxLength(250);
                producto.Property(p=>p.Price)
                        .IsRequired();
                producto.Property(p=>p.Stock)
                        .IsRequired();
                producto.HasOne(p=>p.Provider)
                        .WithMany(p=>p.Products)
                        .HasForeignKey(p=>p.IdProvider);
                producto.HasData(products);
            });

            List<Sale> sales = new List<Sale>();
            sales.Add(
                new Sale()
                {
                    IdSale = Guid.NewGuid(),
                    IdProducto = products[0].IdProduct,
                    Quantity = 1,
                    Total = products[0].Price,
                    Date = DateTime.Now
                }
            );
            sales.Add(
                new Sale()
                {
                    IdSale = Guid.NewGuid(),
                    IdProducto = products[1].IdProduct,
                    Quantity = 2,
                    Total = products[1].Price * 2,
                    Date = DateTime.Now
                }
            );
            modelBuilder.Entity<Sale>(venta=>{
                venta.HasKey(v=>v.IdSale);
                venta.Property(v=>v.IdSale)
                     .HasDefaultValueSql("NEWID()");
                venta.Property(v=>v.Quantity)
                     .IsRequired();
                venta.Property(v=>v.Total)
                     .IsRequired();
                venta.Property(v=>v.Date)
                     .IsRequired();
                venta.HasOne(v=>v.Product)
                     .WithMany(v=>v.Sales)
                     .HasForeignKey(v=>v.IdProducto);
                venta.HasData(sales);
            });



        }


    }
}
