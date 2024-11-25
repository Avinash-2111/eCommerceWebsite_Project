using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Task2product.Interface;
using Task2product.Models;
using Task2product.Service;

namespace Task2product.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {

        private readonly IFactory _fcustomer;
        private readonly IFCustomerRoles _fCustomerRoles;
        private readonly IFRoleMap _fRoleMap;
        public AdminController(IFactory ifactory, IFCustomerRoles ifCustomerRoles, IFRoleMap ifrolemap)
        {
            _fcustomer = ifactory;
            _fCustomerRoles = ifCustomerRoles;
            _fRoleMap = ifrolemap;

        }
        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> Index()
        {
            List<Customer> list1 = await _fcustomer.GetAllAsync();
            List<CustomerRoles> list2 = await _fcustomer.GetAllCustomersAsync();
            List<RoleMapping> list3 = await _fRoleMap.GetAll();
            ViewBag.List1 = list1;
            ViewBag.List2 = list2;
            ViewBag.List3 = list3;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int CustomerId)
        {
            var customer = await _fcustomer.GetById(CustomerId);
            var role = await _fRoleMap.GetByCustomerId(CustomerId);

            ViewBag.customerroles = await _fCustomerRoles.GetAllCustomerRolesAsync();
            ViewBag.customerselectedrole = role;
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer,int[] RoleId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           
            await _fcustomer.update(customer);
            _fRoleMap.Add(customer.CustomerId, RoleId);
          var customerroles= await _fCustomerRoles.GetByIdAsync(customer.CustomerId);
            
            await _fCustomerRoles.UpdateAsync(customerroles);

            ViewBag.customerroles = await _fCustomerRoles.GetAllCustomerRolesAsync();
            

          return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Customer customer)
        {
            if (customer != null)
            {
                Customer model = await _fcustomer.update(customer);

            }
            List<Customer> list = await _fcustomer.GetAllAsync();
            return Json(list); ;

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Customer model = await _fcustomer.DeleteAsync(id);
            List<Customer> customers = await _fcustomer.GetAllAsync();
            return Json(customers);


        }
        [HttpPost]
        public async Task<IActionResult> DeleteBulk(int[] ids)
        {
            _fcustomer.DeleteBulk(ids);
            List<Customer> customers = await _fcustomer.GetAllAsync();
            return Json(customers);

        }
        [HttpGet]
        public async Task<ActionResult> Search(string? searchString)
        {
            List<Customer> customers = new List<Customer>(); // Initialize products list

            // Retrieve Customers based on search criteria
            if (!string.IsNullOrEmpty(searchString))
            {
                customers = await _fcustomer.searchcustomer(searchString); // Assuming this method retrieves products based on searchString
            }
            else
            {
                customers = await _fcustomer.GetAllAsync(); // Assuming this method retrieves all products
            }
            return Json(customers);
        }

        }
}
