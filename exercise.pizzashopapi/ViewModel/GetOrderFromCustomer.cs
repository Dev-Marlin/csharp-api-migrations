using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModel
{
    public class GetOrderFromCustomer
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public GetPizza Pizza { get; set; }
    }
}
