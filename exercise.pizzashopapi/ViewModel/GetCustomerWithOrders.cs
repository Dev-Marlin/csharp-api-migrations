using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModel
{
    public class GetCustomerWithOrders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetOrderFromCustomer> Orders { get; set; } = [];
    }
}
