using IntelviaStore.Models;
using IntelviaStore.ProductData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Iproduct _iproduct;

        public ProductController(Iproduct iproduct)
        {
            _iproduct = iproduct;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _iproduct.Get();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts( Guid id)
        {
            return await _iproduct.Get(id);
        }
    }
}
