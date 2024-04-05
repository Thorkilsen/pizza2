using System;
namespace Big_mommas_2
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        
        public decimal TotalPrice
        {
            get { return Pizzas.Sum(pizza => pizza.Price); }
        }
    }
}