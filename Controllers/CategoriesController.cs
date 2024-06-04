using AMS3A_SalesAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AMS3A_SalesAPI.Domain;
using AMS3A_SalesAPI.Domain.Request;
using AMS3A_SalesAPI.Domain.DTO;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            
            var categories = await _context.Category.ToListAsync();
            if (categories == null)
                return NotFound();

            var response = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDTO
                {

                    Id = category.Id,
                    Description = category.Description,
                    ImageURL = category.ImageURL
                });
                

            }
            return Ok(response);
            

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
        public ActionResult Post(CategoryRequest categoryRequest)
        {
            var category = new Category(){
                Description = categoryRequest.Description,
                IsActive = true,
                ImageURL = categoryRequest.ImageURL
            };
            _context.Category.Add(category);
            _context.SaveChanges();

            return Ok();
        }
    }
}
