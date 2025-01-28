using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        // Pizzas
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.Include(p => p.Orders).ThenInclude(c => c.Customer).ToListAsync();
        }
        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas.Include(p => p.Orders).ThenInclude(c => c.Customer).FirstAsync(x => x.Id == id);
        }
        public async Task<Pizza> AddPizza(Pizza p)
        {
            await _db.Pizzas.AddAsync(p);
            await _db.SaveChangesAsync();

            return p;
        }

        // Customers
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.Include(c => c.Orders).ThenInclude(p => p.Pizza).ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _db.Customers.Include(c => c.Orders).ThenInclude(p => p.Pizza).FirstAsync(c => c.Id == id);
        }
        public async Task<Customer> AddCustomer(Customer c)
        {
            await _db.Customers.AddAsync(c);
            await _db.SaveChangesAsync();

            return c;
        }

        // Orders
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Where(o => o.CustomerId == id).Include(c => c.Customer).Include(p => p.Pizza).ToListAsync();
        }
        public async Task<Order> CreateOrder(Order o)
        {
            await _db.Orders.AddAsync(o);
            await _db.SaveChangesAsync();

            return o;
        }

        // Toppings
        public async Task<IEnumerable<Topping>> GetToppings()
        {
            return await _db.Toppings.Include(o => o.OrderToppings).ThenInclude(o => o.Order).ToListAsync();
        }

        public async Task<Topping> AddTopping(Topping topping)
        {
            await _db.Toppings.AddAsync(topping);
            await _db.SaveChangesAsync();

            return topping;
        }


        // OrderTopping
        public async Task<IEnumerable<OrderTopping>> GetOrdersToppings()
        {
            return await _db.OrderToppings.Include(o => o.Order).Include(t => t.Topping).ToListAsync();
        }

        public async Task<OrderTopping> AddOrderTopping(OrderTopping orderTopping)
        {
            await _db.OrderToppings.AddAsync(orderTopping);
            await _db.SaveChangesAsync();

            return orderTopping;
        }





    }
}
