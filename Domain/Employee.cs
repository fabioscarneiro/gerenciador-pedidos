using System.ComponentModel.DataAnnotations;

namespace Pedidos.Domain
{
    public class Employee
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmployeeCode { get; set; }

        public Employee(string email, string name)
        {
            this.Email = email;
            this.Name = name;
        }
    }
}
