using Task2product.Interface;
using Task2product.Models;
using Task2product.Service;

namespace Task2product.Factories
{
    public class FCustomer : IFactory
    {
        private readonly ICustomerService _icustomerService;
        public FCustomer(ICustomerService icustomerService)
        {
            _icustomerService = icustomerService;
        }
        public async Task<Customer> Add(Customer model)
        {
            try
            {
                Customer Entity = await _icustomerService.Add(model);
                return Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }

        public async  Task<Customer> DeleteAsync(int Id)
        {

            try
            {
                Customer customer = await _icustomerService.DeleteAsync(Id);
                return customer;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public  void DeleteBulk(int[] ids)
        {
            try
            {
                _icustomerService.DeleteBulk(ids);
            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
         
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            try
            {
                List<Customer> list = await _icustomerService.GetAllAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<List<CustomerRoles>> GetAllCustomersAsync()
        {
            return await _icustomerService.GetAllCustomerRolesAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            try
            {
                Customer model = await _icustomerService.GetById(id);
                return model;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<List<Customer>> searchcustomer(string SearchString)
        {
            try
            {
                List<Customer> list = await _icustomerService.SearchCustomer(SearchString);
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }

        public async Task<Customer> update(Customer customer)
        {
            try
            {
                Customer Entity = await _icustomerService.update(customer);

                return Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

       
    }
}
