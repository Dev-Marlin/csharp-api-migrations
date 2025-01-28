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
                    db.Add(new Order
                    {
                        CustomerId = 1,
                        PizzaId = 1,
                        EstimatedDeliveryTime = new TimeOnly(0, 35, 0)
                    });

                    db.Add(new Order {
                        CustomerId = 2,
                        PizzaId = 2,
                        EstimatedDeliveryTime = new TimeOnly(0, 15, 0)
                    });

                    db.Add(new Order {
                        CustomerId = 3,
                        PizzaId = 3,
                        EstimatedDeliveryTime = new TimeOnly(0, 40, 0)
                    });
                    await db.SaveChangesAsync();
                }

                if (!db.Toppings.Any())
                {
                    db.Add(new Topping
                    {
                        Id = 1,
                        Name = "Pepperoni"
                    });

                    db.Add(new Topping
                    {
                        Id = 2,
                        Name = "Ham"
                    });

                    db.Add(new Topping
                    {
                        Id= 3,
                        Name = "Halloumi"
                    });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
