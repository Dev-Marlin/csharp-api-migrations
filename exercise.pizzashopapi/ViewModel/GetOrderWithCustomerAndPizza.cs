using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModel
{
    public class GetOrderWithCustomerAndPizza
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public GetCustomer Customer { get; set; }
        public GetPizza Pizza { get; set; }
    }
}
