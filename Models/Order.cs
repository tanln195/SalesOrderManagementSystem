using System.ComponentModel.DataAnnotations;

namespace SalesOrderManagementSystem.Models
{
    public class Order
    {
        [Required]
        public string SalesOrder { set; get; }
        [Required]
        public string SalesOrderItem { set; get; }
        [Required]
        public string WorkOrder { set; get; }
        [Required]
        public string ProductID { set; get; }
        [Required]
        public string ProductDescription { set; get; }
        [Required]
        public decimal OrderQty { set; get; }
        [Required]
        public string OrderStatus { set; get; }
        public DateTime Timestamp { set; get; }
    }
}

