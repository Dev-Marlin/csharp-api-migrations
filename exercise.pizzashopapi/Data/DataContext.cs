using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Data
{
    public class DataContext : DbContext
    {
        private string connectionString;
        public DataContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Order>().HasKey(a => new { a.CustomerId, a.PizzaId });
            modelBuilder.Entity<Order>().HasOne(p => p.Pizza).WithMany(o => o.Orders).HasForeignKey(o => o.PizzaId);
            modelBuilder.Entity<Order>().HasOne(c => c.Customer).WithMany(o => o.Orders).HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderTopping>().HasKey(a => new { a.CustomerId, a.PizzaId, a.ToppingId});
            modelBuilder.Entity<OrderTopping>().HasOne(t => t.Topping).WithMany(ot => ot.OrderToppings).HasForeignKey(o => o.ToppingId);
            modelBuilder.Entity<OrderTopping>().HasOne(o => o.Order).WithMany(ot => ot.OrderToppings).HasPrincipalKey(o => new { o.CustomerId, o.PizzaId});
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);

            //set primary of order?

            //seed data?

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<OrderTopping> OrderToppings { get; set; }
    }
}
