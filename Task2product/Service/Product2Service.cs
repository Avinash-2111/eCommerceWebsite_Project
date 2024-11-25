using Microsoft.EntityFrameworkCore;
using Task2product.Context;
using Task2product.Interface;
using Task2product.Models;

namespace Task2product.Service
{
    public class Product2Service:Product2Interface
    {
     

          private ProductContext2 db;
         public Product2Service(ProductContext2 context)
         {
         db = context;

         }
    

        public async Task<Product2> delete(int id)
        {
            try
            {

                Product2 model = await db.product2s.FindAsync(id);

                if (model != null)
                {
                    var Entity = db.product2s.Remove(model);
                    db.SaveChanges();
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
                db.SaveChanges();
            }


        }
        public void deleteBulk(int[] ids)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (int id in ids)
                    {
                        var entity = db.product2s.Find(id);
                        if (entity != null)
                        {
                            db.product2s.Remove(entity);
                        }
                
                    }

                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApplicationException("Error Deleting in Products", ex);
                    
                }
               
            }

        }
        public async Task<List<Product2>> getbypagenation(int? pageno, int? pagesize)
        {
            try
            {

                List<Product2> list = await db.product2s.OrderBy(s => s.ProductId).Skip((pageno.Value - 1) * pagesize.Value).Take(pagesize.Value).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }
        }

        public async Task<List<Product2>> getall()
        {
            try
            {
                List<Product2> list = await db.product2s.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }
        }
        

        public async Task<Product2> getbyid(int id)
        {
            try
            {
                Product2 model = await db.product2s.FindAsync(id);
                return model;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }
        }

        public async Task<Product2> post(Product2 model)
        {
            try
            {
                var Entity = await db.product2s.AddAsync(model);
                db.SaveChanges();
                return Entity.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }
        }

        public async Task<Product2> update(Product2 model)
        {
            try
            {
                var Entity = db.product2s.Update(model);
                db.SaveChanges();
                return Entity.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }
        }
        public async Task<List<Product2>> SearchProduct(string searchString)
        {
            try
            {
                if (string.IsNullOrEmpty(searchString))
                {
                    throw new ArgumentNullException(nameof(searchString));
                }


                var query = db.product2s.Where(l =>
                    l.ProductName.ToLower().Contains(searchString.ToLower()) ||
                    l.Category.ToLower().Contains(searchString.ToLower()));
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally
            {
                db.SaveChanges();
            }

        }
    }
}
