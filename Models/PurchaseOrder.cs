using System.ComponentModel.DataAnnotations;

namespace Purchase.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public SupplierModel Supplier { get; set; }

        public string Observations { get; set; }

        public string Status { get; set; } // Ativo ou Finalizado

        public DateTime CreationDate { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
