using Task2product.Models;

namespace Task2product.Interface
{
    public interface IFactory
    {
        public Task<Customer> Add(Customer model);
        public Task<List<CustomerRoles>> GetAllCustomersAsync();
        public Task<List<Customer>> searchcustomer(String SearchString);
        public void DeleteBulk(int[] ids);
        public Task<Customer> DeleteAsync(int Id);
        public Task<List<Customer>> GetAllAsync();
        public Task<Customer> GetById(int id);
        public Task<Customer> update(Customer customer);




    }
}
