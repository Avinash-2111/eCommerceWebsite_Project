using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2product.Interface;
using Task2product.Models;
using Task2product.Service;
using static Task2product.Models.Product2;

namespace Task2product.Controllers
{
    public class ProductController2 : Controller
    {

        private Product2Interface Product2Service;
       // IValidator<Product2> Validator;
        public ProductController2(Product2Interface product /*, IValidator<Product2> Validator*/)
        {
            this.Product2Service = product;
           // this.Validator = Validator;
        }
        public async Task<IActionResult> Index(int? page = 1, int? pageSize = 5)
        {

            int pageNumber = page ?? 1;
            int pageSizeNumber = pageSize ?? 5;
            List<Product2> list = await Product2Service.getall();
            int totalCount = list.Count;

            List<Product2> products = await Product2Service.getbypagenation(page.Value, pageSize.Value);


            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSizeNumber;
            ViewBag.TotalCount = totalCount;


            return View(products);
        }

        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Product2 product2)
        {
            

            IFormFile uploadedFile = Request.Form.Files["ImageFile"];
            using (var stream = uploadedFile.OpenReadStream())
            {
                byte[] fileBytes = new byte[uploadedFile.Length];
                int bytesRead = stream.Read(fileBytes, 0, (int)uploadedFile.Length);
                product2.ImageFile = fileBytes;
            }
            if (product2 != null)
            {
               await Product2Service.post(product2);
            }
            List<Product2> products = await Product2Service.getall();
            return Json(products);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            Product2 model = await Product2Service.getbyid(id);
            return Json(model);

        }
        [HttpPost]
        public async Task<IActionResult> Update(Product2 product2)
        {
            
            IFormFile uploadedFile = Request.Form.Files["ImageFile"];
            using (var stream = uploadedFile.OpenReadStream())
            {
                byte[] fileBytes = new byte[uploadedFile.Length];
                int bytesRead = stream.Read(fileBytes, 0, (int)uploadedFile.Length);
                product2.ImageFile = fileBytes;
            }
            if (product2 != null)
            {
                Product2 model = await Product2Service.update(product2);

            }
            List<Product2> list= await Product2Service.getall();
            return Json(list); ;


        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product2 model = await Product2Service.delete(id);
            List<Product2> products = await Product2Service.getall();
            return Json(products);
            

        }
        [HttpPost]
        public async Task<IActionResult> DeleteBulk(int[] ids)
        {
            Product2Service.deleteBulk(ids);
            List<Product2> products = await Product2Service.getall();
            return Json(products);

        }
        [HttpGet]
        public async Task<ActionResult> Search(string? searchString, string? sortBy)
        {
            List<Product2> products = new List<Product2>(); // Initialize products list

            // Retrieve products based on search criteria
            if (!string.IsNullOrEmpty(searchString))
            {
                products = await Product2Service.SearchProduct(searchString); // Assuming this method retrieves products based on searchString
            }
            else
            {
                products = await Product2Service.getall(); // Assuming this method retrieves all products
            }

            // Sorting logic based on sortBy parameter
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "ProductId":
                        products = products.OrderBy(l => l.ProductId).ToList();
                        break;
                    case "ProductName":
                        products = products.OrderBy(l => l.ProductName).ToList();
                        break;
                    case "Description":
                        products = products.OrderBy(l => l.Description).ToList();
                        break;
                    case "Price":
                        products = products.OrderBy(l => l.Price).ToList();
                        break;
                    case "Category":
                        products = products.OrderBy(l => l.Category).ToList();
                        break;
                    case "StockQuantity":
                        products = products.OrderBy(l => l.StockQuantity).ToList();
                        break;
                    case "DateAdded":
                        products = products.OrderBy(l => l.DateAdded).ToList();
                        break;
                    default:
                        products = products.OrderBy(l => l.ProductId).ToList(); // Default sorting by ProductId
                        break;
                }

                // Check if TempData and ViewBag are initialized before using them
                if (TempData.ContainsKey("CurrentSort") && TempData["CurrentSort"].ToString() == sortBy)
                {
                    products.Reverse();
                    ViewBag.CurrentSortOrder = ViewBag.CurrentSortOrder == "asc" ? "desc" : "asc";
                }
                else
                {
                    ViewBag.CurrentSortOrder = "asc";
                }
            }

            TempData["CurrentSort"] = sortBy; // Store current sort order in TempData

            return Json(products); // Return products as JSON
        }
  
        public async Task<IActionResult> ProductDetail(int ProductId)
        {
            var Product = await Product2Service.getbyid(ProductId);
            if(Product==null)
            {
                return NotFound();
            }

            return View(Product);
        }

    }
}
