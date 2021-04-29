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
using TestAspCore.DTOs;
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
        [HttpGet]
     
        public async Task<ActionResult<IEnumerable<CategorieModel>>> GetCategory()
        {
            
            return await _db.Categories
                .Select(x=>new CategorieModel() { 
                    id=x.id,
                    Nom=x.Nom,
                 
                    SourceImage=string.Format("{0}://{1}{2}/Images/{3}",Request.Scheme,Request.Host,Request.PathBase,x.ImageName),
                    Image=x.Image,

                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
       
        public async Task<CategorieModel> GetCategory(Guid id)
        {
            return await _store.Get(id);
        }

        //[HttpPost]

        //public async Task<ActionResult<CategorieModel>> PostCategorys([FromForm] CategorieModel categorie)
        //{
        //    //categorie.ImageName = await SaveImages(categorie.Image);
        //    //var newCategorie = await _store.Create(categorie);
        //    var NewCategory = new CategorieModel
        //    {
        //        Nom = categorie.Nom,
        //        ImageName = categorie.ImageName
        //    };
        //    _db.Categories.Add(NewCategory);
        //    await _db.SaveChangesAsync();
        //    return StatusCode(201);
        //}


        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto categoryDto)
        {
            var NewCategory = new CategorieModel
            {
                Nom = categoryDto.Nom,
                ImageName = categoryDto.ImageName
            };

            _db.Categories.Add(NewCategory);
            await _db.SaveChangesAsync();
            return Ok(categoryDto);
            //if (result > 0)
            //{
            //    return StatusCode(201);
            //} else
            //{
            //    return StatusCode()
            //}
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


        [NonAction]
        public async Task<string> SaveImages(IFormFile image)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(image.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return imageName;
        }

    }
}


