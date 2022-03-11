using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain.Products;
using Pedidos.Infra.Data;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController: ControllerBase
    {
        readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            var _category = new Category
            {
                Name = category.Name,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                ModifiedBy = "Test",
                ModifiedOn = DateTime.Now,
            };

            _context.Categories.Add(_category);
            _context.SaveChanges();

            return Created("/category", _category.Id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _context.Categories.Select(c => new { c.Name, c.Active, c.Id});
            return Ok(categories);
        }

        [HttpPut]
        public IActionResult Put(Category category)
        {
            var newCategory = _context.Categories.Where(c=>c.Id == category.Id).FirstOrDefault();
            if(newCategory == null)
            {
                return NotFound();
            }

            newCategory.Name = category.Name;
            newCategory.Active = category.Active;
            newCategory.ModifiedBy = "Test";
            newCategory.ModifiedOn = DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }
    }
}
