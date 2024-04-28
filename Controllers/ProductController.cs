using AMS3A_SalesAPI.Context;
using AMS3A_SalesAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AMS3A_SalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        public ProductController(ApplicationDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _context.Product.ToList();
        }

        [HttpGet]
        [Route("id:Guid")]
        public ActionResult<Product> GetByProductId(Guid id)
        {
            var product = _context.Product.FirstOrDefault(r => r.Id == id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception) {
                return BadRequest();
            }

        }
       
    }
}
