using Task2product.Models;

namespace Task2product.Interface
{
    public interface IFCustomerRoles
    {
        public Task<CustomerRoles> GetByIdAsync(int id);
        public Task<List<CustomerRoles>> GetAll();
        public Task<List<CustomerRoles>> GetAllCustomerRolesAsync();
        public Task<CustomerRoles> AddAsync(CustomerRoles customerroles);
        public Task<CustomerRoles> UpdateAsync(CustomerRoles customerroles);
        public Task<CustomerRoles> DeleteAsync(int Id);
        public void DeleteBulk(int[] ids);
        public Task<List<CustomerRoles>> SearchCustomerRoles(String SearchRole);
    }
}
