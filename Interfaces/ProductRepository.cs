using Microsoft.EntityFrameworkCore;
using ODataExample.Context;
using ODataExample.Models;

namespace ODataExample.Interfaces {
    public class ProductRepository(AppDbContext context) : IProductRepository {
        public async Task<bool> AddAsync(Product product) {
            await context.Products.AddAsync(product);
            var changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken) {
            return await context.Products.ToListAsync();
        }
    }
}
