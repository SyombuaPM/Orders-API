using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersAPI.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }


        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Customer name cannot be null or empty");
                }
                _customerName = value;
            }
        }

            private DateTime orderDate = DateTime.Today;

            public DateTime OrderDate
            {
                get { return orderDate; }
                private set { orderDate = value; }
            }

            public string GetFormattedOrderDate()
            {
                return OrderDate.ToString("yyyy-MM-dd");
            }
    





        public ICollection<Order_Items> OrderItems { get; set; } = new List<Order_Items>();
        // this is a property OrderItems is of type ICollection<Order_Items> and it is initialized 
        //to a new List<Order_Items>(), this intialization ensures that OrderItems is never null, 
        //and it can be used to add and remove items from the collection.





    }
}

