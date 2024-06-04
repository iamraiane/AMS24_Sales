using AMS3A_SalesAPI.Context;
using AMS3A_SalesAPI.Domain;
using AMS3A_SalesAPI.Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult Post(ProductRequest productRequest)
        {
            var product = new Product(){
                Description = productRequest.Description,
                Stock = productRequest.Stock,
                Price = productRequest.Price,
                ImageURL = productRequest.ImageURL,
                CategoryId = productRequest.CategoryId,
            };
            _context.Product.Add(product);
            _context.SaveChanges();
            return Ok();

        }
       
    }
}
