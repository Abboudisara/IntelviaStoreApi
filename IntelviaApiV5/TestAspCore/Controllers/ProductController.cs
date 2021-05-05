using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;
using TestAspCore.Repositories;

namespace TestAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IStoreRepository<ProductModel> _store;
        private readonly IStoreRepository<CategorieModel> _storeCat;

        public ProductController(IStoreRepository<ProductModel> store, IStoreRepository<CategorieModel> storeCat)
        {
            _store = store;
            _storeCat = storeCat;
        }
        [HttpGet]

        public async Task<IEnumerable<ProductModel>> GetProduct()
        {
            return await _store.Get();
        }

        [HttpGet("{id}")]

        public async Task<ProductModel> Getproduct(Guid id)
        {
            return await _store.Get(id);
        }

        [HttpPost]

        public async Task<IActionResult> Postproduct([FromBody] ProductModel product)
        {
           // product.Categories = await _storeCat.Get(product.Catgo_id);
            await _store.Create(product);
            return StatusCode(201);
        }

        [HttpPut]

        public async Task<ActionResult<ProductModel>> PutCategorys(Guid id, [FromBody] ProductModel product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }
            await _store.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var productDelet = await _store.Get(id);
            if (productDelet == null)
                return NotFound();
            await _store.Delete(productDelet.id);
            return NoContent();
        }
    }
}
