using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain.Products;
using Pedidos.Infra.Data;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController: ControllerBase
    {
        public IActionResult Post(Category category, ApplicationDbContext context)
        {
            var _category = new Category
            {
                Name = category.Name,
            };

            context.Categories.Add(_category);  
            context.SaveChanges();

            return CreatedAtAction("/category", _category.Id);
        }
    }
}
