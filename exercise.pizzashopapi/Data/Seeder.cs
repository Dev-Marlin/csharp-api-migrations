using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using(var db = new DataContext())
            {
                if(!db.Customers.Any())
                {
                    db.Add(new Customer() { Id = 1, Name="Nigel" });
                    db.Add(new Customer() { Id = 2, Name = "Dave" });
                    db.Add(new Customer() { Id = 3, Name = "Martin" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Id = 1,Name = "Vegan Cheese Tastic" });
                    db.Add(new Pizza() { Id = 2,Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Id = 3,Name = "Kebab" });
                    await db.SaveChangesAsync();

                }

                //order data
                if(!db.Orders.Any())
                {
                    db.Add(new Order { 
                        CustomerId = 1,
                        //Customer = new Customer() { Id = 1,Name = "Nigel" },
                        PizzaId = 1,
                        //Pizza = new Pizza() { Id = 1,Name = "Vegan Cheese Tastic" }
                    });

                    db.Add(new Order {
                        CustomerId = 2,
                        //Customer = new Customer() { Id = 2, Name = "Dave" },
                        PizzaId = 2,
                        //Pizza = new Pizza() { Id = 2,Name = "Cheese & Pineapple" }
                    });

                    db.Add(new Order {
                        CustomerId = 3,
                        //Customer = new Customer() { Id = 3, Name = "Martin" },
                        PizzaId = 3,
                        //Pizza = new Pizza() { Id = 3,Name = "Kebab" }
                    });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
