using OrdersAPI.Models;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.DAL;

namespace OrdersAPI.DAL
{
    public class OrderItemServices(OrderDbContext context)
    {
        private readonly OrderDbContext _context = context;


        public Order_Items AddOrderItem( Order_Items orderItem)
        {
            _context.Order_Items.Add(orderItem);
            _context.SaveChanges();
            return orderItem;
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


        public Order_Items AddOrderItemToOrder(int orderId, Order_Items orderItem)
        {
            var order = _context.Orders.Find(orderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            orderItem.OrderID = orderId;
            _context.Order_Items.Add(orderItem);
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

        public IEnumerable<Order_Items> GetAllOrderItems(int OrderID)
        {
            return _context.Order_Items.Where(o => o.OrderID == OrderID).ToList();
        }

        internal IEnumerable<Order_Items> GetOrderItems(int orderId)
        {
            return _context.Order_Items.Where(o => o.OrderID == orderId).ToList();
        }
        //public Order_Items GetOrderItem(int id, int itemId)

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
    }

}

