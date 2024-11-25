using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Task2product.Models
{
    public class Product2
    {
        
        [Key]
      
        public int ProductId { get; set; }
        [Required(ErrorMessage ="ProductName is Required"), StringLength(100)]
        public string ProductName { get; set; } = "";
        [Required(ErrorMessage ="Description is Required"), StringLength(100)]
        public string Description { get; set; } = "";
        [Precision(16, 2)]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="Category is Required"), StringLength(100)]
        public string Category { get; set; } = "";
        [Required(ErrorMessage ="StockQuantity is Required")]
        public int StockQuantity { get; set; }
        [Required(ErrorMessage ="DateAdded is Required")]
        public DateTime DateAdded { get; set; }
        [DataType(DataType.Upload)]
        public byte[]? ImageFile { get; set; }

        //public class Product2VValidator : AbstractValidator<Product2>
        //{
        //    public Product2VValidator()
        //    {
        //        RuleFor(x => x.ProductName)
        //            .NotEmpty().WithMessage("Product Name is required")
        //            .MaximumLength(100).WithMessage("Product Name cannot exceed 100 characters");

        //        RuleFor(x => x.Description)
        //            .NotEmpty().WithMessage("Description is required")
        //            .MaximumLength(100).WithMessage("Description cannot exceed 100 characters");

        //        RuleFor(x => x.Price)
        //            .NotEmpty().WithMessage("Price is required")
        //            .GreaterThan(0).WithMessage("Price must be greater than 0");

        //        RuleFor(x => x.Category)
        //            .NotEmpty().WithMessage("Category is required")
        //            .MaximumLength(100).WithMessage("Category cannot exceed 100 characters");

        //        RuleFor(x => x.StockQuantity)
        //            .NotEmpty().WithMessage("Stock Quantity is required")
        //            .GreaterThan(0).WithMessage("Stock Quantity must be greater than 0");

        //        RuleFor(x => x.DateAdded)
        //            .NotEmpty().WithMessage("Date Added is required");
        //    }
        //}
    }
}
