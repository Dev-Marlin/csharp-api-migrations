using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzas = app.MapGroup("/pizzashop");

            pizzas.MapGet("/pizzas", GetPizzas);
            pizzas.MapPost("/pizzas/add", AddPizza);

            pizzas.MapGet("/orders", GetOrders);
            pizzas.MapGet("/orders/{id}", GetOrderByCustomer);
            pizzas.MapPost("orders/add/{pizzaid}/{customerid}", CreateOrder);

            pizzas.MapGet("/customers", GetCustomers);
            pizzas.MapGet("/customers/{id}", GetCustomerById);
            pizzas.MapPost("/customers/add", AddCustomer);
        }

        // Pizza endpoints
        public static async Task<IResult> GetPizzas(IRepository repo)
        {
            var pizzas = await repo.GetPizzas();

            List<GetPizzaWithOrders> pizzaList = new List<GetPizzaWithOrders>();

            foreach (var pizza in pizzas)
            {
                List<GetOrderFromPizza> orderList = new List<GetOrderFromPizza>();

                foreach(var order in pizza.Orders)
                {
                    GetCustomer getCustomer = new GetCustomer()
                    {
                        Id = order.CustomerId,
                        Name = order.Customer.Name
                    };

                    GetOrderFromPizza gtop = new GetOrderFromPizza()
                    {
                        CustomerId = order.CustomerId,
                        PizzaId = order.PizzaId,
                        Customer = getCustomer
                    };
                }

                GetPizzaWithOrders getPizza = new GetPizzaWithOrders()
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Price = pizza.Price,
                    Orders = orderList
                };
            }

            return TypedResults.Ok(pizzaList);
        }

        public static async Task<IResult> AddPizza(IRepository repo, Pizza pizza)
        {
            GetPizza getPizza = new GetPizza()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price
            };

            await repo.AddPizza(pizza);

            return TypedResults.Ok(getPizza);
        }


        // Order endpoints
        public static async Task<IResult> GetOrders(IRepository repo)
        {
            var orders = await repo.GetOrders();

            List<GetOrderWithCustomerAndPizza> orderList = new List<GetOrderWithCustomerAndPizza>();

            foreach (var order in orders)
            {
                GetCustomer gc = new GetCustomer()
                {
                    Id = order.Customer.Id,
                    Name = order.Customer.Name
                };

                GetPizza gp = new GetPizza()
                {
                    Id = order.Pizza.Id,
                    Name = order.Pizza.Name,
                    Price = order.Pizza.Price
                };

                GetOrderWithCustomerAndPizza go = new GetOrderWithCustomerAndPizza()
                {
                    CustomerId = order.CustomerId,
                    PizzaId = order.PizzaId,
                    Customer = gc,
                    Pizza = gp
                };

                orderList.Add(go);
            }
            return TypedResults.Ok(orderList);
        }

        public static async Task<IResult> GetOrderByCustomer(IRepository repo, int id)
        {
            var orders = await repo.GetOrdersByCustomer(id);

            List<GetOrderWithCustomerAndPizza> orderList = new List<GetOrderWithCustomerAndPizza>();

            foreach (var order in orders)
            {
                GetCustomer gc = new GetCustomer()
                {
                    Id = order.Customer.Id,
                    Name = order.Customer.Name
                };

                GetPizza gp = new GetPizza()
                {
                    Id = order.Pizza.Id,
                    Name = order.Pizza.Name,
                    Price = order.Pizza.Price
                };

                GetOrderWithCustomerAndPizza go = new GetOrderWithCustomerAndPizza()
                {
                    CustomerId = order.CustomerId,
                    PizzaId = order.PizzaId,
                    Customer = gc,
                    Pizza = gp
                };

                orderList.Add(go);
            }
            return TypedResults.Ok(orderList);
        }

        public static async Task<IResult> CreateOrder(IRepository repo, int customerId, int pizzaId)
        {
            var customer = await repo.GetCustomerById(customerId);
            var pizza = await repo.GetPizzaById(pizzaId);

            Order tempOrder = new Order()
            {
                CustomerId = customerId,
                PizzaId = pizzaId,
                Customer = customer,
                Pizza = pizza
            };

            var order = await repo.CreateOrder(tempOrder);

            GetCustomer gc = new GetCustomer()
            {
                Id = order.Customer.Id,
                Name = order.Customer.Name
            };

            GetPizza gp = new GetPizza()
            {
                Id = order.Pizza.Id,
                Name = order.Pizza.Name,
                Price = order.Pizza.Price
            };

            GetOrderWithCustomerAndPizza go = new GetOrderWithCustomerAndPizza()
            {
                CustomerId = order.CustomerId,
                PizzaId = order.PizzaId,
                Customer = gc,
                Pizza = gp
            };

            return TypedResults.Ok(go);
        }


        // Customer endpoints

        public static async Task<IResult> GetCustomers(IRepository repo)
        {
            var customers = await repo.GetCustomers();

            List<GetCustomerWithOrders> customerList = new List<GetCustomerWithOrders>();

            foreach (var customer in customers)
            {
                List<GetOrderFromCustomer> orderList = new List<GetOrderFromCustomer>();

                foreach (var order in customer.Orders)
                {
                    GetPizza getPizza = new GetPizza()
                    {
                        Id= order.Pizza.Id,
                        Name = order.Pizza.Name, 
                        Price = order.Pizza.Price
                    };

                    GetOrderFromCustomer getOrder = new GetOrderFromCustomer()
                    {
                        CustomerId = order.CustomerId,
                        PizzaId = order.PizzaId,
                        Pizza =getPizza
                    };

                    orderList.Add(getOrder);
                }

                GetCustomerWithOrders gcwo = new GetCustomerWithOrders()
                {
                    Id=customer.Id,
                    Name = customer.Name,
                    Orders = orderList
                };

                customerList.Add(gcwo);
            }

            return TypedResults.Ok(customerList);
        }

        public static async Task<IResult> GetCustomerById(IRepository repo, int id)
        {
            var customer = await repo.GetCustomerById(id);

            List<GetOrderFromCustomer> orderList = new List<GetOrderFromCustomer>();

            foreach (var order in customer.Orders)
            {
                GetPizza getPizza = new GetPizza()
                {
                    Id = order.Pizza.Id,
                    Name = order.Pizza.Name,
                    Price = order.Pizza.Price
                };

                GetOrderFromCustomer getOrder = new GetOrderFromCustomer()
                {
                    CustomerId = order.CustomerId,
                    PizzaId = order.PizzaId,
                    Pizza = getPizza
                };

                orderList.Add(getOrder);
            }

            GetCustomerWithOrders gcwo = new GetCustomerWithOrders()
            {
                Id = customer.Id,
                Name = customer.Name,
                Orders = orderList
            };
            
            return TypedResults.Ok(gcwo);
        }

        public static async Task<IResult> AddCustomer(IRepository repo, Customer c)
        {
            var customer = await repo.AddCustomer(c);

            GetCustomer gc = new GetCustomer()
            {
                Id = customer.Id,
                Name = customer.Name
            };

            return TypedResults.Ok(gc);
        }
    }
}
