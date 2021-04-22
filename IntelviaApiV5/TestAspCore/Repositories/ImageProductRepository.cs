using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Authentication;
using TestAspCore.Models;

namespace TestAspCore.Repositories
{
    public class ImageProductRepository : IStoreRepository<ImageProduct>
    {
        private readonly ApplicationDbContext _db;
        public ImageProductRepository (ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ImageProduct> Create(ImageProduct product)
        {
            _db.Image_Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task Delete(Guid id)
        {
            var ImageDelet = await _db.Image_Products.FindAsync(id);
            _db.Image_Products.Remove(ImageDelet);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImageProduct>> Get()
        {
            var ImageLits = await _db.Image_Products.ToListAsync();
            return ImageLits;
        }

        public async Task<ImageProduct> Get(Guid id)
        {
            return await _db.Image_Products.FindAsync(id);
        }

        public async Task Update(ImageProduct product)
        {
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
