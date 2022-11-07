using KensShopOnline.Api.Data;
using KensShopOnline.Api.Entities;
using KensShopOnline.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KensShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly KensShopOnlineDbContext kensShopOnlineDbContext;

        public ProductRepository(KensShopOnlineDbContext kensShopOnlineDbContext)
        {
            this.kensShopOnlineDbContext = kensShopOnlineDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.kensShopOnlineDbContext.ProductCategories.ToListAsync();

            return categories;

        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await kensShopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await kensShopOnlineDbContext.Products
                                .Include(p => p.ProductCategory)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.kensShopOnlineDbContext.Products
                                     .Include(p => p.ProductCategory).ToListAsync();

            return products;

        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            var products = await this.kensShopOnlineDbContext.Products
                                     .Include(p => p.ProductCategory)
                                     .Where(p => p.CategoryId == id).ToListAsync();
            return products;
        }
    }
}
