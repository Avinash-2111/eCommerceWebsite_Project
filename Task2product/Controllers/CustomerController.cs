using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Task2product.Factories;
using Task2product.Interface;
using Task2product.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;



namespace Task2product.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IFactory _fcustomer;
        private readonly IFCustomerRoles _fCustomerRoles;
        private readonly IFRoleMap _fRoleMap;
        public CustomerController(IFactory fcustomer, IFCustomerRoles fCustomerRoles, IFRoleMap fRoleMap)
        {
            _fcustomer = fcustomer;
            _fCustomerRoles = fCustomerRoles;
            _fRoleMap = fRoleMap;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var customerroles = new CustomerRoles();
            Customer customer = new Customer();
            ViewBag.CustomerRoles1 = await _fcustomer.GetAllCustomersAsync();
            return View(customer);
            //List<CustomerRoles> roles = await _fcustomer.GetAllCustomersAsync();
            //ViewBag.roles = roles;
            //return View();

        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer model, int[] RoleId)
        {

            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //Customer Model = await _fcustomer.Add(model);
            //_fRoleMap.Add(model.CustomerId, RoleId);

            //return RedirectToAction("Login");
            try
            {
                Customer customer = await _fcustomer.Add(model);
                _fRoleMap.Add(customer.CustomerId, RoleId);
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                return BadRequest("Missing required information.");
            }


        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Login(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            List<Customer> list1 = await _fcustomer.searchcustomer(customer.Username);
            Customer model = list1.FirstOrDefault();
            List<RoleMapping> list = await _fRoleMap.GetByCustomerId(model.CustomerId);
            ClaimsIdentity identity = null;
            List<CustomerRoles> roles = new List<CustomerRoles>();
            foreach (var item in list)
            {
                roles.Add(await _fCustomerRoles.GetByIdAsync(item.RoleId));
            }
            string Assigrnrole = null;

            foreach (var item in roles)
            {
                if (item.RoleName == "Admin")
                {

                    Assigrnrole = item.RoleName;
                }
                else if (item.RoleName == "Guest")
                {
                    Assigrnrole = item.RoleName;
                }
            }
            if (string.IsNullOrEmpty(Assigrnrole))
            {
                Assigrnrole = "User";
            }

            bool isAuthenticate = false;
            if (customer.Username == model.Username && model.Password == customer.Password)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,model.Username),
                    new Claim(ClaimTypes.Role,Assigrnrole)
                },
                CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "ProductController2");
            }


            return BadRequest("user not found");
        }
        [HttpGet]
        public async  Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Policy ="AdminPolicy")]
        public IActionResult AdminAction()
        {
            return View();
        }
        [Authorize(Policy = "UserPolicy")]
        public IActionResult UserAction()
        {
            return View();
        }
        [Authorize(Policy = "GuestPolicy")]
        public IActionResult GuestAction()
        {
            return View();
        }
    }




      

    }

