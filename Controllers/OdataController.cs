using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataExample.Context;
using ODataExample.Models;
using System.Reflection;

namespace ODataExample.Controllers {
    [Route("odata")]
    [ApiController]
    [EnableQuery]
    public class OdataController(AppDbContext context) : ODataController {


        public static IEdmModel GetEdmModel() {
            var builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();
            builder.EntitySet<Product>("products");
            builder.EntitySet<Category>("categories");
            return builder.GetEdmModel();
        }


        [HttpGet("{name}")]
        public IActionResult GetProducts(string name) {
            //name değişkenini kullanarak context nesnesindeki property'leri getiriyoruz.
            var propertyInfo = context.GetType().GetProperty(
            name,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance );
       
            if (propertyInfo == null) {
                return NotFound();
            }

            var dbSet = propertyInfo.GetValue(context) as IQueryable;
            if (dbSet == null)
                return NotFound();

            return Ok(dbSet);
        }
    }
}
