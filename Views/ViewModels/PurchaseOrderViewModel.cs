using Purchase.Models;
using System.ComponentModel.DataAnnotations;

namespace Purchase.Views.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public PurchaseOrder PurchaseOrder { get; set; }

        [Display(Name = "Produtos")]
        public List<ProductModel> Products { get; set; }

        [Display(Name = "Fornecedores")]
        public List<SupplierModel> Suppliers { get; set; }
    }
}
