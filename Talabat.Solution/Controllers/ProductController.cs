using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contracts;
using Talabat.Core.Specification;

namespace Talabat.Solution.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;

       
        public ProductController(IGenericRepository<Product> productsRepo)
        {
            _productsRepo = productsRepo;
            this._productsRepo = productsRepo;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var spec = new BaseSpecifications<Product>();
            var products = await _productsRepo.GetAllWithSpecAsync(spec);
            //IEnumerable<Product>? products = await _productsRepo.GetAllAsync();
            //OkObjectResult result = new OkObjectResult(products);
            //return result;
            return Ok(products);


        }
        



    }
}
