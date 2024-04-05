using System;
namespace Big_mommas_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MenuCatalog
    {
        private List<Pizza> pizzas = new List<Pizza>(); 

        public MenuCatalog()
        {
            AddPizza(new Pizza("Pepperoni", 5.99m, new List<string> { "Pepperoni", "Cheese", "Tomato Sauce" }));
            AddPizza(new Pizza("Margherita", 4.99m, new List<string> { "Cheese", "Tomato Sauce", "Basil" }));
            AddPizza(new Pizza("Hawaiian", 6.49m, new List<string> { "Ham", "Cheese", "Pineapple", "Tomato Sauce" }));
        }

        public void AddPizza(Pizza pizza)
        {
            pizzas.Add(pizza);
        }

        public void DeletePizza(string name)
        {
            Pizza pizza = pizzas.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (pizza != null)
            {
                pizzas.Remove(pizza);
            }
        }

        public Pizza FindPizza(string name)
        {
            return pizzas.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }


        public void PrintMenu()
        {
            if (pizzas.Count == 0)
            {
                Console.WriteLine("The menu is currently empty.");
                return;
            }

            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"{pizza.Name} - ${pizza.Price}");
                Console.WriteLine("Ingredients: " + string.Join(", ", pizza.Ingredients));
                Console.WriteLine();
            }
        }


        public void UpdatePizza(string name, decimal newPrice, List<string> newIngredients)
        {
            var pizzaToUpdate = pizzas.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (pizzaToUpdate != null)
            {
                pizzaToUpdate.Price = newPrice;
                pizzaToUpdate.Ingredients = newIngredients;
                Console.WriteLine($"{name} pizza updated successfully.");
            }
            else
            {
                Console.WriteLine($"Pizza named {name} not found.");
            }
        }
    }
}