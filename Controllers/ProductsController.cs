using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataExample.Context;
using ODataExample.Interfaces;
using ODataExample.Models;

namespace ODataExample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(AppDbContext context) : ControllerBase {
       
        
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product) {

            var productList = new List<Product>();
            for (int i = 0; i < 100; i++) {
                var faker = new Faker();
                var p = new Product() {
                    Name = faker.Commerce.ProductName(),
                    Price = faker.Random.Decimal(1, 100),
                    Description = faker.Lorem.Sentence(),
                    PriceTotal = faker.Random.Decimal(1, 100),
                };
                productList.Add(p);
            }

            await context.Products.AddRangeAsync(productList);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetProduct() {
            var categoryList = new List<Category>();    
           
            for (int i = 0; i < 100; i++) {
                var faker = new Faker();
                var c = new Category() {
                    Name = faker.Lorem.Word(),
                    Description = faker.Lorem.Sentence()
                };
                categoryList.Add(c);
            }

            await context.Categories.AddRangeAsync(categoryList);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
