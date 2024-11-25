using Task2product.Models;
using Task2product.Service;

namespace Task2product.Factories
{
    public class CartFactory : ICartFactory
    {
        private readonly ICartService _icartservice;
        public CartFactory(ICartService icartservice)
        {
            _icartservice = icartservice;
        }
        public async Task<Cart> Add(Cart cartmodel)
        {
            try
            {
                return await _icartservice.Add(cartmodel);
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> customercartquantity(int CustomerId)
        {
              var p=  await _icartservice.customercartquantity(CustomerId);
            return p;
        }

        public async Task<List<Cart>> GetAll(int CustomerId)
        {
            try
            {
                return await _icartservice.GetAll(CustomerId);
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
          
        }

        public async Task<bool> Remove(int CustomerId, int ProductId)
        {
              try
              {
                return await _icartservice.Remove(CustomerId, ProductId);
              }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
           
        }

        public Task<bool> RemoveAll(int CustomerId)
        {
            try
            {
                return _icartservice.RemoveAll(CustomerId);
            }
            catch(Exception ex)
            {

                throw new NotImplementedException();
            }
        }

        public async Task<Cart> Search(int CustomerId, int ProductId)
        {
            try
            {
                return await _icartservice.Search(CustomerId, ProductId);
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            
        }

        public  async Task<Cart> Update(Cart cartmodel)
        {
            try 
            {
                return await _icartservice.Update(cartmodel);
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
