namespace exercise.pizzashopapi.Models
{
    public class OrderTopping
    {
        public int ToppingId { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public Order Order { get; set; }
        public Topping Topping { get; set; }
    }
}
