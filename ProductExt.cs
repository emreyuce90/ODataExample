using Microsoft.EntityFrameworkCore;
using ODataExample.Context;

namespace ODataExample {
    public static class ProductExt {

        public static void AddProductApi(this WebApplication application) {
            application.MapGet("/",async (AppDbContext context)=>await context.Products.ToListAsync()).WithDisplayName("").WithTags();
        }
    }
}
