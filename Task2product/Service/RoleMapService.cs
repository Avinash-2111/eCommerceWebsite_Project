using Microsoft.EntityFrameworkCore;
using Task2product.Context;
using Task2product.Factories;
using Task2product.Interface;
using Task2product.Models;

namespace Task2product.Service
{
    public class RoleMapService : IRoleMap
    {
        private readonly ProductContext2 _productContext;
        public RoleMapService(ProductContext2 productContext)
        {
            _productContext = productContext;
        }
        public void Add(int CustomerId, int[] RoleId)
        {
            foreach(int id in RoleId)
            {
                RoleMapping rolemap = new RoleMapping()
                {
                    CustomerId = CustomerId,
                    RoleId = id
                };
                _productContext.roleMappings.Add(rolemap);
                _productContext.SaveChanges();
            }

        }

        public async Task<List<RoleMapping>> GetAll()
        {
            List<RoleMapping> roleMAps = await _productContext.roleMappings.ToListAsync();
            return roleMAps;
        }


      public  async Task<List<RoleMapping>> GetByCustomerId(int CustomerId)
        {
            var query = await _productContext.roleMappings.Where(map =>
              map.CustomerId == CustomerId).ToListAsync();
            return query.ToList();
        }
    }
}
