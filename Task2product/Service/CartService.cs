using Microsoft.EntityFrameworkCore;
using Task2product.Context;
using Task2product.Models;

namespace Task2product.Service
{
    public class CartService : ICartService
    {
        private readonly ProductContext2 _cartcontext;
        public CartService(ProductContext2 cartcontext)
        {
            _cartcontext = cartcontext;
        }
        public  async Task<Cart> Add(Cart cartmodel)
        {
            try
            {

                _cartcontext.carts.Add(cartmodel);
                await _cartcontext.SaveChangesAsync();
                return cartmodel;
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                await _cartcontext.SaveChangesAsync();
            }
           

        }

        public  async Task<int> customercartquantity(int CustomerId)
        {
            await Task.Delay(500);
            try
            {

                return await _cartcontext.carts
                      .Where(c => c.CustomerId == CustomerId)
                      .SumAsync(c => c.Quantity);

                //  return  totalQuantity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in customercartquantity: {ex.Message}");
                return -1;
            }
       

        }

        public  async Task<List<Cart>> GetAll(int CustomerId)
        {
            try
            {
                var cartItems = await _cartcontext.carts
               .Where(c => c.CustomerId == CustomerId)
               .ToListAsync();

                return cartItems;
            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
           
        }

        public async Task<bool> Remove(int CustomerId, int ProductId)
        {

            try
            {
                var cartItem = await _cartcontext.carts
                    .FirstOrDefaultAsync(c => c.CustomerId == CustomerId && c.ProductId == ProductId);

                if (cartItem != null)
                {
                    _cartcontext.carts.Remove(cartItem);
                    await _cartcontext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while removing the product from the cart.", ex);
            }

        }

        public async Task<bool> RemoveAll(int CustomerId)
        {
            try
            {
                var cartItems = await _cartcontext.carts
                    .Where(c => c.CustomerId == CustomerId)
                    .ToListAsync();

                if (cartItems != null && cartItems.Count > 0)
                {
                    _cartcontext.carts.RemoveRange(cartItems);
                    await _cartcontext.SaveChangesAsync();
                    return true;
                }

                return false; // No items found for the customer ID
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while removing all cart items.", ex);
            }

        }

        public  async Task<Cart> Search(int CustomerId, int ProductId)
        {
            try
            {
                var cartItem = await _cartcontext.carts
              .FirstOrDefaultAsync(c => c.CustomerId == CustomerId && c.ProductId == ProductId);

                return cartItem;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
          
        }

        public async Task<Cart> Update(Cart cartmodel)
        {
            try
            {
                _cartcontext.carts.Update(cartmodel);
                await _cartcontext.SaveChangesAsync();
                return cartmodel;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException occurred: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Exception occurred: {ex.Message}");
                throw new ApplicationException("An error occurred while updating the cart.", ex);
            }
        }

    }
}
