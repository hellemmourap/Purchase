using System.ComponentModel.DataAnnotations;

namespace Purchase.Models
{
    public class SupplierModel
    {
            public int Id { get; set; }

            public string Name { get; set; }

            public bool IsActive { get; set; }   
    }
}
