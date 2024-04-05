using System;
namespace Big_mommas_2
{
    public class Pizza
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string> Ingredients { get; set; }

        public Pizza(string name, decimal price, List<string> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }
}