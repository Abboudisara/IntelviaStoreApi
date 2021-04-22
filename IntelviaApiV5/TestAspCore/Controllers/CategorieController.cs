using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Authentication;
using TestAspCore.Models;
using TestAspCore.Repositories;

namespace TestAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly IStoreRepository<CategorieModel> _store;
        private readonly ApplicationDbContext _db;
        public CategorieController(IStoreRepository<CategorieModel> store , ApplicationDbContext db)
        {
            _store = store;
            _db = db;
        }


        //Api Categorie
        [HttpGet]
     
        public async Task<ActionResult<IEnumerable<CategorieModel>>> GetCategory()
        {
            
            return await _db.Categories
                .Select(x=>new CategorieModel() { 
                    id=x.id,
                    Nom=x.Nom,
                 
                    SourceImage=string.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,x.ImageNam),
                    Image=x.Image,

                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
       
        public async Task<CategorieModel> GetCategory(Guid id)
        {
            return await _store.Get(id);
        }

        [HttpPost]

        public async Task<ActionResult<CategorieModel>> PostCategorys([FromBody] CategorieModel categorie)
        {
            var newCategorie = await _store.Create(categorie);
            return CreatedAtAction(nameof(GetCategory), new { id = newCategorie.id }, newCategorie);
        }

        //[HttpPost]
        //public string post([FromForm] CategorieModel categorie)
        //{
        //    try
        //    {
        //        if (categorie.image.Length > 0)
        //        {
        //            string path = _store.webRoutPath + "\\uploads\\";
        //        }
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        else
        //                {
        //                    return "Not uploded";
        //                }
        //    }
    
    [HttpPut]
        
        public async Task<ActionResult<CategorieModel>> PutCategorys(Guid id, [FromBody] CategorieModel categorie)
        {
            if (id != categorie.id)
            {
                return BadRequest();
            }
            await _store.Update(categorie);
            return NoContent();
        }

        [HttpDelete("{id}")]
       
        public async Task<ActionResult> Delete(Guid id)
        {
            var categorieDelet = await _store.Get(id);
            if (categorieDelet == null)
                return NotFound();
            await _store.Delete(categorieDelet.id);
            return NoContent();
        }

    }
}
