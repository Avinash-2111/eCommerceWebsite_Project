using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2product.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product2")]
        public int ProductId { get; set; }
        public Product2? Product2 { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int Quantity { get; set; }
    }
}
