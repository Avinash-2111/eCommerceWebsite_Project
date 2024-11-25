using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using Task2product.Factories;
using Task2product.Interface;
using Task2product.Models;

namespace Task2product.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartFactory _cartfactory;
        private readonly IFactory _fcustomer;
        private readonly Product2Interface _product2service;
        public CartController(ICartFactory cartfactory, IFactory fcustomer, Product2Interface product2service)
        {
            _cartfactory = cartfactory;
            _fcustomer = fcustomer;
            _product2service = product2service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddToCart(int Quantity, int ProductId)
        {
            if (User.Identity.IsAuthenticated)
            {
                string Username = User.FindFirstValue(ClaimTypes.Name);
                List<Customer> list1 = await _fcustomer.searchcustomer(Username);
                Customer model1 = list1.FirstOrDefault();
                Cart existscart = await _cartfactory.Search(model1.CustomerId, ProductId);
                if (existscart == null)
                {
                    Cart cart = new Cart()
                    {
                        CustomerId = model1.CustomerId,
                        ProductId = ProductId,
                        Quantity = Quantity
                    };
                    _cartfactory.Add(cart);
                }
                else
                {
                    int i = existscart.Quantity;
                    existscart.Quantity = i + Quantity;
                    _cartfactory.Update(existscart);
                }
                int qty = await _cartfactory.customercartquantity(model1.CustomerId);
                return Json(qty);
            }
            return View();
        }
        public async Task<ActionResult> CartItems()
        {
            string Username = User.FindFirstValue(ClaimTypes.Name);
            List<Customer> list1 = await _fcustomer.searchcustomer(Username);
            Customer model1 = list1.FirstOrDefault();
            List<Cart> cartitems = await _cartfactory.GetAll(model1.CustomerId);
            if(cartitems.Count>0)
            {
                int quantity = await _cartfactory.customercartquantity(cartitems[0].CustomerId);
                ViewBag.Quantity = quantity;
            }
            return Json(cartitems);
        }
    public async Task<IActionResult> ViewCart()
        {
            string Username = User.FindFirstValue(ClaimTypes.Name);
            List<Customer> list1 = await _fcustomer.searchcustomer(Username);
            Customer model1 = list1.FirstOrDefault();
            if (model1 != null)
            {
                List<Cart> cartlist = await _cartfactory.GetAll(model1.CustomerId);
               Product2 products = await _product2service.getbyid(model1.CustomerId);
                List<Product2> productslist = new List<Product2>();
                 foreach(var cartitem in cartlist)
                {
                    Product2 product2 = await _product2service.getbyid(cartitem.ProductId);
                    Product2 productnew = new Product2
                        {
                        ProductId=product2.ProductId,
                        ProductName=product2.ProductName,
                        Description=product2.Description,
                        ImageFile=product2.ImageFile,
                        StockQuantity=cartitem.Quantity,


                    };
                    productslist.Add(productnew);
                }

                return View(productslist);

            }
            else
            {
                return NotFound();
            }
        }
      public async Task<IActionResult> UpdateCartQuantity(int ProductId,int Quantity)
        {

            string Username = User.FindFirstValue(ClaimTypes.Name);
            List<Customer> list1 = await _fcustomer.searchcustomer(Username);
            Customer model1 = list1.FirstOrDefault();
            List<Cart> cartitems = await _cartfactory.GetAll(model1.CustomerId);
            Cart existscart = await _cartfactory.Search(model1.CustomerId, ProductId);
            if(existscart!=null)
            {
                int i = existscart.Quantity;
                existscart.Quantity = Quantity;
                _cartfactory.Update(existscart);
            }
            int qty = await _cartfactory.customercartquantity(cartitems[0].CustomerId);
            ViewBag.Quantity = qty;

            return Json(cartitems);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveCartItem(int productId)
        {
            try
            {
               
                string Username = User.FindFirstValue(ClaimTypes.Name);
                var customerList = await _fcustomer.searchcustomer(Username);
                var customer = customerList.FirstOrDefault();

                if (customer != null)
                {
                    int customerId = customer.CustomerId;
                    bool removed = await _cartfactory.Remove(customerId, productId);
                    if (removed)
                    {
                        return RedirectToAction("ViewCart", "Cart");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Item not found in your cart.";
                        return RedirectToAction("ViewCart", "Cart");
                    }
                }
                else
                {
                     return NotFound("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"Error in RemoveCartItem: {ex.Message}");

                TempData["ErrorMessage"] = "An error occurred while removing the item from your cart.";
                return RedirectToAction("ViewCart", "Cart");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            try
            {

                string Username = User.FindFirstValue(ClaimTypes.Name);
                List<Customer> list1 = await _fcustomer.searchcustomer(Username);
                Customer model1 = list1.FirstOrDefault();
                await _cartfactory.RemoveAll(model1.CustomerId);
                return Ok("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error in ClearCart: {ex.Message}");
                
                return BadRequest("An error occurred while clearing the cart.");
            }
        }





    }
}
