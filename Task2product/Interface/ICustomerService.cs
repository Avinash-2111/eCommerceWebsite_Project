using Task2product.Models;

namespace Task2product.Interface
{
    public interface ICustomerService
    {
        public   Task<Customer> Add(Customer model);
        public   Task<Customer> DeleteAsync(int id);
        public void DeleteBulk(int[] ids);
        public Task<List<Customer>> SearchCustomer(string searchString);

        public Task<List<Customer>> GetAllAsync();
        public Task<Customer> GetById(int id);
        public Task<List<CustomerRoles>> GetAllCustomerRolesAsync();
        public  Task<Customer> update(Customer customer);
    }
}
