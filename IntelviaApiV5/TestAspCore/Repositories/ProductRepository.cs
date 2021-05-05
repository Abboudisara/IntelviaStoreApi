using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Authentication;
using TestAspCore.Models;

namespace TestAspCore.Repositories
{
    public class ProductRepository : IStoreRepository<ProductModel>
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public string webRoutPath => throw new NotImplementedException();

        public async Task<ProductModel> Create(ProductModel product)
        {
            _db.productsI.Add(product);
            await _db.SaveChangesAsync();
            return product;

        }

        public  async Task Delete(Guid id)
        {
            var productDelet = await _db.productsI.FindAsync(id);
            _db.productsI.Remove(productDelet);
            await _db.SaveChangesAsync();

        }

        public async Task<IEnumerable<ProductModel>> Get()
        {
            var productList = await _db.productsI.ToListAsync() ;
            return productList;
        }

        public async Task<ProductModel> Get(Guid id)
        {
            return await _db.productsI.FindAsync(id);
        }

        public async Task Update(ProductModel product)
        {
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
