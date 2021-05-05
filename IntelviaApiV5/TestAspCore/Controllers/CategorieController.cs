using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategorieController(IStoreRepository<CategorieModel> store , ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _store = store;
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }


        //Api Categorie
        //[HttpGet]
     
        //public async Task<ActionResult<IEnumerable<CategorieModel>>> GetCategory()
        //{
            
        //    return await _db.Categories
        //        .Select(x=>new CategorieModel() { 
        //            id=x.id,
        //            Nom=x.Nom,
                 
        //            SourceImage=string.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,x.ImageName),
        //            Image=x.Image,

        //        })
        //        .ToListAsync();
        //}

        [HttpGet("{id}")]
       
        public async Task<CategorieModel> GetCategory(Guid id)
        {
            return await _store.Get(id);
        }



        [HttpPost]
        public async Task<ActionResult<CategorieModel>> Post([FromBody] CategorieModel category)
        {
            //category.ImageName = await SaveImage(category.ImageFile);
            await _store.Create(category);
            return StatusCode(201);
        }

       

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


        //[NonAction]
        //public async Task<string> SaveImage(IFormFile imageFile)
        //{
        //    string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray());
        //    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
        //    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
        //    using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //    {
        //        await imageFile.CopyToAsync(fileStream);
        //    }
        //    return imageName;
        //}

    }
}


