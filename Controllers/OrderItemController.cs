using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using OrdersAPI.DAL;
using OrdersAPI.Models;

namespace OrdersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemServices _orderItemService;

        public OrderItemController(OrderItemServices orderItemServices)
        {
            _orderItemService = orderItemServices;
        }

        // [HttpGet("{orderId}")]
        // public ActionResult<IEnumerable<Order_Items>> GetAllOrderItems(int orderId)
        // {
        //     var orderItems = _orderItemService.GetOrderItems(orderId);

        //     if (orderItems == null || !((IEnumerable<Order_Items>)orderItems).Any())
        //     {
        //         return NotFound(new { Error = "No order items found for this order" });
        //     }

        //     return Ok(orderItems);
        // }

        // [HttpPost("{orderId}")]
        // public ActionResult<Order_Items> AddOrderItemToOrder(int orderId, [FromBody] Order_Items orderItem)
        // {
        //     var order = _orderItemService.GetOrderItems(orderId);

        //     if (order == null)
        //     {
        //         return NotFound(new { Error = "Order not found" });
        //     }

        //     orderItem.OrderID = orderId;
        //     _orderItemService.AddOrderItem(orderItem);

        //     return CreatedAtAction(nameof(AddOrderItemToOrder), new { id = orderItem.ItemID }, orderItem);
        // }

        

        // [HttpPut("{orderId}/{itemId}")]
        // public ActionResult<Order_Items> UpdateOrderItem(int orderId, int itemId, [FromBody] Order_ItemUpdate orderItemUpdate)
        // {
        //     var orderItem = _orderItemService.GetOrderItem(orderId, itemId);

        //     if (orderItem == null)
        //     {
        //         return NotFound(new { Error = "Order item not found" });
        //     }

        //     orderItem.ProductName = orderItemUpdate.ProductName;
        //     orderItem.Quantity = orderItemUpdate.Quantity;
        //     orderItem.Price = orderItemUpdate.Price;

        //     _orderItemService.UpdateOrderItem(orderItem);

        //     return Ok(orderItem);
        // }

        

        // [HttpDelete("{orderId}/{itemId}")]
        // public ActionResult DeleteOrderItem(int orderId, int itemId)
        // {
        //     var orderItem = _orderItemService.GetOrderItem(orderId, itemId);

        //     if (orderItem == null)
        //     {
        //         return NotFound(new { Error = "Order item not found" });
        //     }

        //     _orderItemService.DeleteOrderItem(orderId, itemId);

        //     return Ok(new { Message = "Order item deleted successfully" });
        // }












    }
}

