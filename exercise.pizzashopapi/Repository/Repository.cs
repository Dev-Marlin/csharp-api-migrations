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
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.Include(p => p.Orders).ToListAsync();
        }
        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas.Include(p => p.Orders).FirstAsync(x => x.Id == id);
        }
        public async Task<Pizza> AddPizza(Pizza p)
        {
            await _db.Pizzas.AddAsync(p);
            await _db.SaveChangesAsync();

            return p;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.Include(c => c.Orders).ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _db.Customers.Include(c => c.Orders).FirstAsync(c => c.Id == id);
        }
        public async Task<Customer> AddCustomer(Customer c)
        {
            await _db.Customers.AddAsync(c);
            await _db.SaveChangesAsync();

            return c;
        }


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

    }
}
