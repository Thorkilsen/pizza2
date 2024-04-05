using System;
namespace Big_mommas_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerCatalog
    {
        private List<Customer> customers = new List<Customer>();
        private int nextId = 1;

        public void AddCustomer(string name, string email)
        {
            Customer customer = new Customer(nextId++, name, email); 
            customers.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id); 
            if (customer != null)
            {
                customers.Remove(customer);
            }
        }

        public void UpdateCustomer(int id, string newName, string newEmail)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id); 
            if (customer != null)
            {
                customer.Name = newName;
                customer.Email = newEmail;
            }
        }

        public Customer SearchCustomerByName(string name)
        {
            return customers.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void PrintCustomers()
        {
            foreach (Customer customer in customers) 
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
            }
        }
    }
}
