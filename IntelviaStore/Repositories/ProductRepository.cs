
using IntelviaStore.Authentication;
using IntelviaStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.ProductData
{
    public class ProductRepository : Iproduct
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository( ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product)
        {
            _context.produit.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(Guid id)
        {
            var productToDelete = await _context.produit.FindAsync(id);
            _context.produit.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Product>> Get()
        {
            return await _context.produit.ToListAsync();
        }

        public async  Task<Product> Get(Guid id)
        {
            return await _context.produit.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

