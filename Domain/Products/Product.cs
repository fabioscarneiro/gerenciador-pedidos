using System.ComponentModel.DataAnnotations;

namespace Pedidos.Domain.Products
{
    public class Product : Entity
    {
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool HasStock { get; set; }
    }
}
