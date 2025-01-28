using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public ICollection<OrderTopping> OrderToppings { get; set; }
        public TimeOnly EstimatedDeliveryTime { get; set; }
    }
}
