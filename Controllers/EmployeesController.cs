using Microsoft.AspNetCore.Mvc;
using Pedidos.Infra.Data;
using Pedidos.Domain;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        readonly UserManager<IdentityUser> _userManager;

        public EmployeesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var user = new IdentityUser { UserName = employee.Email, Email = employee.Email };
            var result = _userManager.CreateAsync(user, employee.Password).Result;

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var userClaims = new List<Claim>
            {
                new Claim("EmployeeCode", employee.EmployeeCode),
                new Claim("Name", employee.Name)
            };

            var claimResult = _userManager.AddClaimsAsync(user, userClaims).Result;

            if (!claimResult.Succeeded)
                return BadRequest(claimResult.Errors.First());



            return Created("/employees", user.Id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userManager.Users.ToList();
            var employees = new List<Employee>();
            foreach (var user in users)
            {
                var claims = _userManager.GetClaimsAsync(user).Result;
                var clainName = claims.FirstOrDefault(c => c.Type == "Name");
                var name = clainName != null ? clainName.Value : string.Empty;
                
                employees.Add(new Employee(user.Email,name));
            }

            var result = employees.Select(e => new { e.Name, e.Email }).OrderBy(x => x.Name);
            return Ok(result);
        }
    }
}
