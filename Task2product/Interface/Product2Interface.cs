using Task2product.Models;

namespace Task2product.Interface
{
    public interface Product2Interface
    {
        public Task<List<Product2>> getall();
        public Task<List<Product2>> getbypagenation(int? pageno, int? pagesize);

        public Task<Product2> getbyid(int id);
        public Task<Product2> post(Product2 model);
        public Task<Product2> update(Product2 model);
        public Task<Product2> delete(int id);
        public void deleteBulk(int[] ids);
        public Task<List<Product2>> SearchProduct(string searchString);

    
}
}
