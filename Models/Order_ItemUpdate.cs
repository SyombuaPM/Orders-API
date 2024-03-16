using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class Order_ItemUpdate
    {
        [Required]
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                _price = value;
            }
        }
    }
}

