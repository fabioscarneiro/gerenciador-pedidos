
using System.ComponentModel.DataAnnotations;

namespace Pedidos.Domain.Products
{
    public class Category : Entity
    {
        [Required(ErrorMessage = "O nome é obrigatório", AllowEmptyStrings =false)]
        [StringLength(50)]
        public string Name { get; set; }
       
    }
}
