using Task2product.Interface;
using Task2product.Models;
using Task2product.Service;

namespace Task2product.Factories
{
    public class FRoleMap : IFRoleMap
    {
        private readonly IRoleMap _irolemap;
        public FRoleMap(IRoleMap irolemap)
        {
            _irolemap = irolemap;
        }
        public void Add(int CustomerId, int[] RoleId)
        {
            _irolemap.Add(CustomerId, RoleId);
        }

        public  async Task<List<RoleMapping>> GetAll()
        {
            List<RoleMapping> roleMAps = await _irolemap.GetAll();
            return roleMAps;
        }

           
    public async Task<List<RoleMapping>> GetByCustomerId(int CustomerId)
        {
            List<RoleMapping> list = await _irolemap.GetByCustomerId(CustomerId);
            return list;
        }
    }
}
