using System.ComponentModel.DataAnnotations;

namespace Task2product.Models
{
    public class CustomerRoles
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
