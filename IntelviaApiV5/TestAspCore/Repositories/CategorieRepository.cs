using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Authentication;
using TestAspCore.Models;

namespace TestAspCore.Repositories
{
    public class CategorieRepository : IStoreRepository<CategorieModel>
    {
        private readonly ApplicationDbContext _db;
        public CategorieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public string webRoutPath => throw new NotImplementedException();

        public async Task<CategorieModel> Create(CategorieModel categorie)
        {
            _db.Categories.Add(categorie);
            await _db.SaveChangesAsync();
            return categorie;

        }

        public  async Task Delete(Guid id)
        {
            var categorieDelet = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(categorieDelet);
            await _db.SaveChangesAsync();

        }

        public async Task<IEnumerable<CategorieModel>> Get()
        {
            var categoriesLits = await _db.Categories.ToListAsync();
            return categoriesLits;
        }

        public async Task<CategorieModel> Get(Guid id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public  async Task Update(CategorieModel categorie)
        {
            _db.Entry(categorie).State = EntityState.Modified;
            await _db.SaveChangesAsync();

        }

       
    }
}
