using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task2product.Interface;

namespace Task2product.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Policy ="UserOnly")]
    public class UserController : Controller
    {
        private readonly IFactory _fcustomer;
        private readonly IFCustomerRoles _fCustomerRoles;
        private readonly IFRoleMap _fRoleMap;
        public UserController(IFactory factory, IFCustomerRoles fCustomerRoles, IFRoleMap fRoleMap)
        {
            _fcustomer = factory;
            _fCustomerRoles = fCustomerRoles;
            _fRoleMap = fRoleMap;
        }
        [Authorize(Policy = "UserOnly")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
