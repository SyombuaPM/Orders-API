using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using OrdersAPI.DAL;
using OrdersAPI.Models;

namespace OrdersAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
   {
        private readonly Orderservices _orderService;

        public OrderController(Orderservices orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]// Retrieving a list of all orders
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            if (_orderService.GetOrders().ToList().Count == 0)
            {
                return NotFound(new { Error = "No orders found" });
            }
            return _orderService.GetOrders().ToList();
        }

        [HttpGet("{Id}")] // Retrieving details of a specific order
        public ActionResult<Order> GetOrder(int Id)
        {
            var order = _orderService.GetOrder(Id);
            if (order == null)
            {
                return NotFound(new { Error = " No Order with that ID found" });
            }
            return Ok(order);
        }

        [HttpPost]//for creating a new order
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            var newOrder = _orderService.AddOrder(order);
            return CreatedAtAction(nameof(CreateOrder), new { id = newOrder.OrderID }, newOrder);
        }

        [HttpPut("{id}")]
        public ActionResult<Order> UpdateOrder(int id, [FromBody] Order order)
        {
            try
            {
                var updatedOrder = _orderService.UpdateOrder(order);
                return Ok(updatedOrder);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = "No input found" });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }

        [HttpGet("{orderId}/items")]

        public ActionResult<IEnumerable<Order_Items>> GetOrderItems(int orderId)
        {
            var orderItems = _orderService.GetOrderItems(orderId);
            if (orderItems == null || !((IEnumerable<Order_Items>)orderItems).Any())
            {
                return NotFound(new { Error = "No order items found for this order" });
            }
            return Ok(orderItems);
        }

         [HttpPost("{orderId}/items")]
        public ActionResult<Order_Items> AddOrderItemToOrder(int orderId, [FromBody] Order_Items orderItem)
        {
            var order = _orderService.GetOrderItems(orderId);

            if (order == null)
            {
                return NotFound(new { Error = "Order not found" });
            }

            orderItem.OrderID = orderId;
            _orderService.AddOrderItem(orderItem);

            return CreatedAtAction(nameof(AddOrderItemToOrder), new { id = orderItem.ItemID }, orderItem);
        }

        // [HttpPut("{orderId}/items/{itemId}/")]
        // public ActionResult<Order_Items> UpdateOrderItem(int orderId, int itemId, [FromBody] Order_Items orderItem)
        // {
        //     try
        //     {
        //         var updatedOrderItem = _orderService.UpdateOrderItem(orderId, itemId, orderItem);
        //         return Ok(updatedOrderItem);
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(new { Error = "No input found" });
        //     }
        // }

        [HttpPut("{orderId}/items/{itemId}")]
        public ActionResult<Order_Items> UpdateOrderItem(int orderId, int itemId, [FromBody] Order_ItemUpdate orderItemUpdate)
        {
            var orderItem = _orderService.GetOrderItem(orderId, itemId);

            if (orderItem == null)
            {
                return NotFound(new { Error = "Order item not found" });
            }

            orderItem.ProductName = orderItemUpdate.ProductName;
            orderItem.Quantity = orderItemUpdate.Quantity;
            orderItem.Price = orderItemUpdate.Price;

            _orderService.UpdateOrderItem(orderItem);

            return Ok(orderItem);
        }

       [HttpDelete("{orderId}/items/{itemId}")]
        public ActionResult DeleteOrderItem(int orderId, int itemId)
        {
            var orderItem = _orderService.GetOrderItem(orderId, itemId);

            if (orderItem == null)
            {
                return NotFound(new { Error = "Order item not found" });
            }

            _orderService.DeleteOrderItem(orderId, itemId);

            return Ok(new { Message = "Order item deleted successfully" });
        }
 

   }
}
