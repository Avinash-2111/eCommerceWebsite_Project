using System.Numerics;
using System.ComponentModel.DataAnnotations;

namespace Task2product.Models
{
    public class Customer
    {
        [Key]
        public   int  CustomerId { get; set; }
        public   string?  FirstName { get; set; }
        public   String?  LastName { get; set; }
        public string? Gender { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }
        public string? Phone { get; set; }
       

    }
}
