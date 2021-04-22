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
    public class ImageProductController : ControllerBase
    {
        private readonly IStoreRepository<ImageProduct> _store;

        public ImageProductController(IStoreRepository<ImageProduct> store)
        {
            _store = store;
        }


        [HttpGet("GetImgP")]

        public async Task<IEnumerable<ImageProduct>> GetImg()
        {
            return await _store.Get();
        }

        [HttpGet("{id}")]

        public async Task<ImageProduct> GetImg(Guid id)
        {
            return await _store.Get(id);
        }

        [HttpPost("PostImgP")]

        public async Task<ActionResult<ImageProduct>> PostImgP([FromBody] ImageProduct Img)
        {
            var newImg = await _store.Create(Img);
            return CreatedAtAction(nameof(GetImg), new { id = newImg.Id_image }, newImg);
        }

        [HttpPut]

        public async Task<ActionResult<ImageProduct>> PutImg(Guid id, [FromBody] ImageProduct Img)
        {
            if (id!= Img.Id_image)
            {
                return BadRequest();
            }
            await _store.Update(Img);
            return NoContent();
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var imgDelet = await _store.Get(id);
            if (imgDelet == null)
                return NotFound();
            await _store.Delete(imgDelet.Id_image);
            return NoContent();
        }
    }
}
