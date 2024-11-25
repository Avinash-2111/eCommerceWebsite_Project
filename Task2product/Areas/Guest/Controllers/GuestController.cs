using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2product.Interface;

namespace Task2product.Areas.Guest.Controllers
{
    [Area("Guest")]
    [Authorize(Policy ="GuestOnly")]
    public class GuestController : Controller
    {
        private readonly IFactory _fcustomer;
        private readonly IFCustomerRoles _fCustomerRoles;
        private readonly IFRoleMap _fRoleMap;
        public GuestController(IFactory factory, IFCustomerRoles fCustomerRoles, IFRoleMap fRoleMap)
        {
            _fcustomer = factory;
            _fCustomerRoles = fCustomerRoles;
            _fRoleMap = fRoleMap;
        }
        [Authorize(Policy = "GuestOnly")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
