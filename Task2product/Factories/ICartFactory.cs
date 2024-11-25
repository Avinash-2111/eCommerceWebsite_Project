using Task2product.Models;

namespace Task2product.Factories
{
    public interface ICartFactory
    {
        public Task<Cart> Add(Cart cartmodel);
        public Task<List<Cart>> GetAll(int CustomerId);
        public Task<Cart> Update(Cart cartmodel);
        public Task<Cart> Search(int CustomerId, int ProductId);
        public Task<int> customercartquantity(int CustomerId);
        public Task<bool> Remove(int CustomerId, int ProductId);
        public Task<bool> RemoveAll(int CustomerId);
    }
}
