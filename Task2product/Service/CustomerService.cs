using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task2product.Context;
using Task2product.Interface;
using Task2product.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Task2product.Service
{
    public class Customerservice : ICustomerService
    {
        private ProductContext2 _context;
        public Customerservice(ProductContext2 context)
        {
            _context = context;  
        }
   

        public Task DeleteAsync(int[] id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            try
            {
                List<Customer> list = await _context.customers.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                _context.SaveChanges();
            }
        }

       
      

      public async  Task<List<CustomerRoles>> GetAllCustomerRolesAsync()
        {
            return await _context.customerRoles.ToListAsync();
            
        }

        public async Task<Customer> Add(Customer model)
        {
            try
            {
                var Entity = await _context.customers.AddAsync(model);
                _context.SaveChanges();
                return Entity.Entity;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                _context.SaveChanges();
            }
        }

       

        public async Task<List<Customer>> SearchCustomer(string searchString)
        {
            try
            {
                if (string.IsNullOrEmpty(searchString))
                {
                    throw new ArgumentNullException(nameof(searchString));
                }


                var query = _context.customers.Where(l =>
                    l.FirstName.ToLower().Contains(searchString.ToLower()) ||
                    l.Username.ToLower().Contains(searchString.ToLower()) ||
                    l.Phone.ToLower().Contains(searchString.ToLower()));
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
               _context.SaveChanges();
            }
        }

        public async  Task<Customer> DeleteAsync(int id)
        {

            try
            {

                Customer model = await _context.customers.FindAsync(id);

                if (model != null)
                {
                    var Entity = _context.customers.Remove(model);
                    _context.SaveChanges();
                    return Entity.Entity;
                }
                else
                {
                    throw new NotImplementedException("The requested model is not currently implemented.");
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                _context.SaveChanges();
            }
        }

        public void DeleteBulk(int[] ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var entity = _context.customers.Find(id);
                    _context.customers.Remove(entity);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                _context.SaveChanges();
            }
        }

        public async Task<Customer> update(Customer customer)
        {
            try
            {
                var Entity = _context.customers.Update(customer);
                _context.SaveChanges();
                return Entity.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                _context.SaveChanges();
            }
        }

        public async Task<Customer> GetById(int id)
        {
            try
            {
                Customer model = await _context.customers.FindAsync(id);
                return model;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                _context.SaveChanges();
            }
        }
    }
}
