using Task2product.Interface;
using Task2product.Models;
using Task2product.Service;

namespace Task2product.Factories
{
    public class FCustomerRoles : IFCustomerRoles
    {
        private readonly ICustomerRolesService _icustomerrolesservice;
        public FCustomerRoles(ICustomerRolesService icustomerrolesservice)
        {
            _icustomerrolesservice = icustomerrolesservice;
        }


        public async Task<CustomerRoles> AddAsync(CustomerRoles customerroles)
        {
            try
            {
                CustomerRoles Entity = await _icustomerrolesservice.AddAsync(customerroles);
                return Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<CustomerRoles> DeleteAsync(int Id)
        {
            try
            {
                CustomerRoles CustomerRole = await _icustomerrolesservice.DeleteAsync(Id);
                return CustomerRole;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public void DeleteBulk(int[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerRoles>> GetAll()
        {
            try
            {
                List<CustomerRoles> list = await _icustomerrolesservice.GetAllCustomerRolesAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }

   


        public async Task<List<CustomerRoles>> GetAllCustomerRolesAsync()
        {

            List<CustomerRoles> list = await _icustomerrolesservice.GetAllCustomerRolesAsync();
            return list;
        }

        public async  Task<CustomerRoles> GetByIdAsync(int id)
        {
            try
            {
                CustomerRoles model = await _icustomerrolesservice.GetByIdAsync(id);
                return model;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

   

        public async Task<List<CustomerRoles>> SearchCustomerRoles(string SearchRole)
        {
            try
            {
                List<CustomerRoles> list = await _icustomerrolesservice.Search(SearchRole);
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<CustomerRoles> UpdateAsync(CustomerRoles customerroles)
        {
            try
            {
               CustomerRoles Entity = await _icustomerrolesservice.UpdateAsync(customerroles);
                return Entity;

               
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }

       
    }
}
