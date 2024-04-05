namespace Big_mommas_2;

using System;
using System.Collections.Generic;
using System.Linq;



class Store
{
    private static MenuCatalog catalog = new MenuCatalog();
    private static CustomerCatalog customerCatalog = new CustomerCatalog();
    private static OrderCatalog orderCatalog = new OrderCatalog(); 

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Add new pizza to the order");
            Console.WriteLine("2. Delete pizza");
            Console.WriteLine("3. Display pizza menu");
            Console.WriteLine("4. Add Customer");
            Console.WriteLine("5. Delete Customer");
            Console.WriteLine("6. Update Customer");
            Console.WriteLine("7. Search for Customer");
            Console.WriteLine("8. List Customers");
            Console.WriteLine("9. Exit");
            Console.WriteLine("10. Update Pizza");
            Console.WriteLine("11. Create Order");
            Console.WriteLine("12. Delete Order");
            Console.WriteLine("13. Update Order");
            Console.WriteLine("14. Search Order");
            Console.WriteLine("15. List Orders");
            Console.Write("Enter choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddPizza();
                        break;
                    case 2:
                        DeletePizza();
                        break;
                    case 3:
                        DisplayPizzaMenu();
                        break;
                    case 4:
                        AddCustomer();
                        break;
                    case 5:
                        DeleteCustomer();
                        break;
                    case 6:
                        UpdateCustomer();
                        break;
                    case 7:
                        SearchCustomer();
                        break;
                    case 8:
                        ListCustomers();
                        break;
                    case 9:
                        running = false;
                        break;
                    case 10:
                        UpdatePizza();
                        break;
                    case 11:
                        CreateOrder();
                        break;
                    case 12:
                        DeleteOrder();
                        break;
                    case 13:
                        UpdateOrder();
                        break;
                    case 14:
                        SearchOrder();
                        break;
                    case 15:
                        ListOrders();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }


    private static void AddPizza()
    {
        Console.Write("Enter pizza name: ");
        string name = Console.ReadLine().ToLower();

        Tuple<string, decimal, List<string>> pizzaDetails = GetPizzaDetailsByName(name); 

        if (pizzaDetails != null)
        {
            Pizza pizza = new Pizza(pizzaDetails.Item1, pizzaDetails.Item2, pizzaDetails.Item3); 
            catalog.AddPizza(pizza);
            Console.WriteLine($"{pizzaDetails.Item1} added to the order at ${pizzaDetails.Item2}.");
        }
        else
        {
            Console.WriteLine("This pizza type is not recognized. Please add it manually or choose a different type.");
        }
    }


    private static Tuple<string, decimal, List<string>> GetPizzaDetailsByName(string name)
    {
        Dictionary<string, Tuple<string, decimal, List<string>>> pizzaOptions = new Dictionary<string, Tuple<string, decimal, List<string>>>
    {
        { "pepperoni", Tuple.Create("Pepperoni", 5.99m, new List<string> { "Pepperoni", "Cheese", "Tomato Sauce" }) },
        { "margherita", Tuple.Create("Margherita", 4.99m, new List<string> { "Cheese", "Tomato Sauce", "Basil" }) },
        { "hawaiian", Tuple.Create("Hawaiian", 6.49m, new List<string> { "Ham", "Cheese", "Pineapple", "Tomato Sauce" }) }
    };

        if (pizzaOptions.ContainsKey(name))
        {
            return pizzaOptions[name];
        }
        return null;
    }

    private static void DeletePizza()
    {
        Console.Write("Enter pizza name to delete: ");
        string name = Console.ReadLine();
        catalog.DeletePizza(name);
        Console.WriteLine($"{name} has been removed from the menu.");
    }

    private static void DisplayPizzaMenu()
    {
        catalog.PrintMenu();
    }

    private static void AddCustomer()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();
        Console.Write("Enter customer email: ");
        string email = Console.ReadLine();
        customerCatalog.AddCustomer(name, email);
        Console.WriteLine("Customer added successfully.");
    }

    private static void DeleteCustomer()
    {
        Console.Write("Enter customer ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            customerCatalog.DeleteCustomer(id);
            Console.WriteLine("Customer deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    private static void UpdateCustomer()
    {
        Console.Write("Enter customer ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new email: ");
            string newEmail = Console.ReadLine();
            customerCatalog.UpdateCustomer(id, newName, newEmail);
            Console.WriteLine("Customer updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    private static void SearchCustomer()
    {
        Console.Write("Enter customer name to search: ");
        string name = Console.ReadLine();
       Customer customer = customerCatalog.SearchCustomerByName(name);
        if (customer != null)
        {
            Console.WriteLine($"Found customer: ID {customer.Id}, Name {customer.Name}, Email {customer.Email}");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

    private static void ListCustomers()
    {
        customerCatalog.PrintCustomers();
    }

    private static void UpdatePizza()
    {
        Console.Write("Enter the name of the pizza you want to update: ");
        string name = Console.ReadLine();

        Console.Write("Enter the new price: ");
        decimal newPrice;
        while (!decimal.TryParse(Console.ReadLine(), out newPrice))
        {
            Console.Write("Invalid input. Please enter a valid price: ");
        }

        Console.Write("Enter the new ingredients (comma-separated): ");
        List<string> newIngredients = Console.ReadLine().Split(',').Select(ingredient => ingredient.Trim()).ToList();

        catalog.UpdatePizza(name, newPrice, newIngredients);
    }





    private static void CreateOrder()
    {
        Console.WriteLine("Creating a new order:");
        Console.Write("Enter customer name for the order: ");
        string customerName = Console.ReadLine();

        Order newOrder = new Order { CustomerName = customerName };

        
        DisplayPizzaMenu(); 

        bool addingPizzas = true;
        while (addingPizzas)
        {
            Console.Write("Enter pizza name to add to the order (or type 'done' to finish): ");
            string pizzaName = Console.ReadLine();

            if (pizzaName.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                addingPizzas = false;
            }
            else
            {
                
                Pizza pizzaToAdd = catalog.FindPizza(pizzaName);
                if (pizzaToAdd != null)
                {
                    newOrder.Pizzas.Add(pizzaToAdd);
                    Console.WriteLine($"{pizzaToAdd.Name} added to the order.");
                }
                else
                {
                    Console.WriteLine("Pizza not found. Please try again.");
                }
            }
        }

        orderCatalog.AddOrder(newOrder);
        Console.WriteLine($"Order for {customerName} created successfully with {newOrder.Pizzas.Count} pizzas.");
    }


    private static void DeleteOrder()
    {
        Console.Write("Enter Order ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            orderCatalog.DeleteOrder(orderId); 
            Console.WriteLine($"Order {orderId} has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid Order ID.");
        }
    }

    private static void UpdateOrder()
    {
        Console.WriteLine("UpdateOrder method called. Implementation depends on specific requirements.");
    }

    private static void SearchOrder()
    {
        Console.Write("Enter Order ID to search for: ");
        if (int.TryParse(Console.ReadLine(), out int orderId))
        {
            Order order = orderCatalog.SearchOrder(orderId); 
            if (order != null)
            {
                Console.WriteLine($"Order found: ID {order.OrderId}, Customer Name: {order.CustomerName}");
                Console.WriteLine("Pizzas in the order:");
                foreach (var pizza in order.Pizzas)
                {
                    Console.WriteLine($"- {pizza.Name}: ${pizza.Price}");
                }
                Console.WriteLine($"Total Order Price: ${order.TotalPrice}");
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Order ID.");
        }
    }


    private static void ListOrders()
    {
        Console.WriteLine("Listing all orders:");
        orderCatalog.ListOrders();
}




}