using System.ComponentModel.DataAnnotations;

namespace Purchase.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Code { get; set;}
        public bool IsActive { get; set; } = true;
    }
}
