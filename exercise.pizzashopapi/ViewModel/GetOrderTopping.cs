namespace exercise.pizzashopapi.ViewModel
{
    public class GetOrderTopping
    {
        public int ToppingId { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public GetTopping GetTopping {  get; set; }
    }
}
