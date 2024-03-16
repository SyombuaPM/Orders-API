using OrdersAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace OrdersAPI.DAL

{

    public class Orderservices(OrderDbContext context)
    {
        private OrderDbContext _context = context;

        public Order AddOrder(Order order)
        {
        
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }
        public Order_Items AddOrderItem(Order_Items orderItem)
        {
            _context.Order_Items.Add(orderItem);
            _context.SaveChanges();
            return orderItem;
        }
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
        public void DeleteOrderItem(int id)
        {
            var orderItem = _context.Order_Items.Find(id);
            if (orderItem != null)
            {
                _context.Order_Items.Remove(orderItem);
                _context.SaveChanges();
            }
        }
        public Order GetOrder(int id)
        {
            return _context.Orders.SingleOrDefault(o => o.OrderID == id);
        }
        public Order_Items GetOrderItem(int id)
        {
            return _context.Order_Items.SingleOrDefault(o => o.ItemID == id);
        }
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }
        public IEnumerable<Order_Items> GetOrderItems()
        {
            return _context.Order_Items.ToList();
        }
        public Order UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
            return order;

        }
        public Order_Items UpdateOrderItem(int OrderID, Order_Items orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            _context.SaveChanges();
            return orderItem;
        }

        internal IEnumerable<Order_Items> GetOrderItems(int orderId)
        {
            return _context.Order_Items.Where(o => o.OrderID == orderId).ToList();
        }

        public Order_Items UpdateOrderItem(int orderId, int itemId, Order_Items orderItem)
        {
            var order = _context.Orders.Find(orderId);
            var orderItemToUpdate = _context.Order_Items.Find(itemId);

            if (order == null || orderItemToUpdate == null)
            {
                throw new Exception("Order or Order Item not found");
            }
            orderItemToUpdate.ItemID = orderItem.ItemID;
            orderItemToUpdate.ProductName = orderItem.ProductName;
            orderItemToUpdate.Quantity = orderItem.Quantity;
            orderItemToUpdate.Price = orderItem.Price;

            _context.Order_Items.Update(orderItemToUpdate);
            _context.SaveChanges();

            return orderItemToUpdate;
        }

         public Order_Items GetOrderItem(int orderId, int itemId)
        {
            return _context.Order_Items.SingleOrDefault(o => o.OrderID == orderId && o.ItemID == itemId);
        }

         public Order_Items UpdateOrderItem(Order_Items orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            _context.SaveChanges();
            return orderItem;
        }

        public Order DeleteOrderItem(int OrderID, int ItemID)
        {
            var order = _context.Orders.Find(OrderID);
            var orderItem = _context.Order_Items.Find(ItemID);
            if (order != null && orderItem != null)
            {
                _context.Order_Items.Remove(orderItem);
                _context.SaveChanges();
            }
            return order;
        }

        

       


    }
}