
using Microsoft.EntityFrameworkCore;
using SimpleUserAuth.Data;
using SimpleUserAuth.Interface;
using SimpleUserAuth.Model;

namespace SimpleUserAuth.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dbContext.products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.products.FindAsync(id);
        }

        public async Task AddProduct(Product product)
        {
            _dbContext.products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _dbContext.products.FindAsync(id);
            if (product != null)
            {
                _dbContext.products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
