using System.ComponentModel.DataAnnotations;

namespace Purchase.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => Quantity * UnitPrice;

        public int PurchaseOrderId { get; set; }

    }
}
