using CarApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApiApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier()
                {
                    Id=1,
                    Name = "Yasmin",
                    Address="Idlib/Syria",
                    
                 });
            modelBuilder.Entity<Car>().HasData(new Car()
            {
                Id=1,
                Model = "2023",
                Gear = 3,
                Km = 5,
                Year = 2023,
                //Parts = new List<Part>() { new Part()
                //{
                //    Id=1,
                //    Name = "Foo",
                //    Price=300,
                //    Quantity=3,
                //    SupplierId=1,
                //} }

            }) ;
            modelBuilder.Entity<Part>().HasData(new Part()
            {
                Id = 2,
                Name = "Moo",
                Price = 90,
                Quantity = 9,
                SupplierId = 1,
                //Cars=new List<Car>() { new Car()
                //{
                //    Id=2,
                //    Model = "2024",
                //    Gear = 4,
                //    Km = 66,
                //    Year = 2024,


                //} }
                
            });

            
        }
    }
}
