using ODataExample.Context;
using ODataExample.Models;


namespace ODataExample.Interfaces {

    public class CategoryRepository : ICategoryRepository {
        
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<bool> AddAsync(Category category) {
            await _context.Categories.AddAsync(category);
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
