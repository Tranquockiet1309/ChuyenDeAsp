using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TranQuocKiet_2123110364.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // danh sách lưu tạm
        private static List<object> categories = new List<object>();
        [HttpGet]
        // GET: api/Category
        public IActionResult GetCategories()
        {
            return Ok(categories);
        }
        [HttpPost]
        // POST: api/Category
        public IActionResult CreateCategory([FromBody] object category)
        {
            categories.Add(category);
            return Ok(category);
        }
        [HttpPut("{id}")]
        // PUT: api/Category/{id}
        public IActionResult UpdateCategory(int id, [FromBody] object category)
        {
            if (id < 0 || id >= categories.Count)
            {
                return NotFound();
            }
            categories[id] = category;
            return Ok(category);
        }
        [HttpDelete("{id}")]
        // DELETE: api/Category/{id}
        public IActionResult DeleteCategory(int id)
        {
            if (id < 0 || id >= categories.Count)
            {
                return NotFound();
            }
            var deletedCategory = categories[id];
            categories.RemoveAt(id);
            return Ok(deletedCategory);
        }
    }
}
