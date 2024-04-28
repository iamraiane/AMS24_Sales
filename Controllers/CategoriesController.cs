using AMS3A_SalesAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AMS3A_SalesAPI.Domain;

namespace AMS3A_SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        public CategoriesController(ApplicationDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _context.Category.ToList();
        }

        [HttpGet]
        [Route("id:Guid")]
        public ActionResult<Category> GetByCategoryId(Guid id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();

            return Ok();
        }
    }
}
