namespace exercise.pizzashopapi.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderTopping> OrderToppings { get; set; } = [];
    }
}
