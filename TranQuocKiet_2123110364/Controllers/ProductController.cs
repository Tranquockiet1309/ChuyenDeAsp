using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TranQuocKiet_2123110364.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // danh sách lưu tạm
        private static List<object> products = new List<object>();

        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] object product)
        {
            products.Add(product);
            return Ok(product);
        }
        [HttpPut("{id}")]
        // PUT: api/Product/{id}
        public IActionResult UpdateProduct(int id, [FromBody] object product)
        {
            if (id < 0 || id >= products.Count)
            {
                return NotFound();
            }
            products[id] = product;
            return Ok(product);
        }
        [HttpDelete("{id}")]
        // DELETE: api/Product/{id}
        public IActionResult DeleteProduct(int id)
        {
            if (id < 0 || id >= products.Count)
            {
                return NotFound();
            }
            var deletedProduct = products[id];
            products.RemoveAt(id);
            return Ok(deletedProduct);
        }

    }
}