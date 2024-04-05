using System;
namespace Big_mommas_2
{
    public class OrderCatalog
    {
        private List<Order> orders = new List<Order>();
        private int nextOrderId = 1;

        public void AddOrder(Order order)
        {
            order.OrderId = nextOrderId++;
            orders.Add(order);
        }

        public void DeleteOrder(int orderId)
        {
            Order order = orders.FirstOrDefault(o => o.OrderId == orderId); 
            if (order != null)
            {
                orders.Remove(order);
            }
        }

        public void UpdateOrder(int orderId, Order updatedOrder)
        {
            Order order = orders.FirstOrDefault(o => o.OrderId == orderId); 
            if (order != null)
            {
                
                order = updatedOrder;
            }
        }

        public Order SearchOrder(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public void ListOrders()
        {
            foreach (Order order in orders) 
            {
                Console.WriteLine($"Order ID: {order.OrderId}"); 
            }
        }
    }
}