using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class Order_Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }

        [ForeignKey("OrderID")]
        //public Order? Order { get; set; }
        public int OrderID { get; set; }

        // these two properties establish a re/ship where each instance of 
        //the current entity is associated with order, and the OrderId property
        // holds the Id of the associated order.


        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product name cannot be null or empty");
                }
                _productName = value;
            }
        }


        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative");
                }
                _quantity = value;
            }
        }

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
