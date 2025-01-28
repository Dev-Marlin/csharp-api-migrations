using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {

        public Task<IEnumerable<Pizza>> GetPizzas();
        public Task<Pizza> GetPizzaById(int id);
        public Task<Pizza> AddPizza(Pizza p);


        public Task<IEnumerable<Order>> GetOrders();
        public Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        public Task<Order> CreateOrder(Order o);


        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<Customer> GetCustomerById(int id);
        public Task<Customer> AddCustomer(Customer c);



    }
}
