using Microsoft.EntityFrameworkCore;
using Task2product.Context;
using Task2product.Factories;
using Task2product.Interface;
using Task2product.Models;

namespace Task2product.Service
{
    public class CustomerRolesService : ICustomerRolesService
    {
        private ProductContext2 _customerrolescontext;
        public CustomerRolesService(ProductContext2 customerrolescontext)
        {
            _customerrolescontext = customerrolescontext;
        }
        public async Task<CustomerRoles> AddAsync(CustomerRoles customerroles)
        {
            var newcustomerrole = new CustomerRoles()
            {
                RoleName = customerroles.RoleName
            };
            await _customerrolescontext.customerRoles.AddAsync(newcustomerrole);
            await _customerrolescontext.SaveChangesAsync();
            return newcustomerrole;
            
        }

  

        public void DeleteBulk(int[] ids)
        {
            throw new NotImplementedException();
        }

      
        public async Task<List<CustomerRoles>> GetAllCustomerRolesAsync()
        {
            var CustomerRoles = await _customerrolescontext.customerRoles.ToListAsync();

            List<CustomerRoles> customerRoles1 = new List<CustomerRoles>();
            foreach (var customerrole in customerRoles1)
            {
                var customerrole2=new CustomerRoles()
                {
                    RoleId = customerrole.RoleId,
                    RoleName = customerrole.RoleName
                };

                CustomerRoles.Add(customerrole2);
            }

            return CustomerRoles;

        }

        public async Task<CustomerRoles> GetByIdAsync(int id)
        {
            CustomerRoles customerRole = await _customerrolescontext.customerRoles.FindAsync(id);
            return customerRole;
        }

        public Task<List<CustomerRoles>> Search(string searchString)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerRoles> UpdateAsync(CustomerRoles customerroles)
        {
            throw new NotImplementedException();
        }

        Task<CustomerRoles> ICustomerRolesService.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

       
    }
}
