using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModel
{
    public class GetOrderFromPizza
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public GetCustomer Customer { get; set; }
    }
}
