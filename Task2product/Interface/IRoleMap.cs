using Task2product.Factories;
using Task2product.Models;

namespace Task2product.Interface
{
    public interface IRoleMap
    {
        public void Add(int CustomerId, int[] RoleId);
        public Task<List<RoleMapping>> GetByCustomerId(int CustomerId);
        public Task<List<RoleMapping>> GetAll();
    }
}
