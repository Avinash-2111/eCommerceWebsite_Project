using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2product.Models
{
    public class RoleMapping
    {
        [Key]
        public int RoleMappingId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("CustomerRoles")]
        public int RoleId { get; set; }
        public CustomerRoles? CustomerRoles { get; set; }
    }
}
