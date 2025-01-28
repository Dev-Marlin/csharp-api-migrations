using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModel
{
    public class GetPizzaWithOrders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<GetOrderFromPizza> Orders { get; set; } = [];
    }
}
