using Microsoft.AspNetCore.Mvc;
using Task2product.Interface;
using Task2product.Models;

namespace Task2product.Components
{
    public class ProductViewComponent:ViewComponent
    {
        List<ComponentIcons> icons = new List<ComponentIcons>();
        public ProductViewComponent()
        {
            icons = ComponentIcons.AllIcons();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ComponentIcons> model = icons;

            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }
    }
}
