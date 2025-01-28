namespace exercise.pizzashopapi.ViewModel
{
    public class GetOrderToppingsInclude
    {
        public int ToppingId { get; set; }
        public int OrderId { get; set; }
        public GetTopping GetTopping {  get; set; }
        public GetOrderWithCustomerAndPizza GetOrder {  get; set; }
    }
}
