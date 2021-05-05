using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Authentication;
using TestAspCore.Models;

namespace TestAspCore.Repositories
{
    public class CommendeRepository : IStoreRepository<CommandeModel>
    {
        private readonly ApplicationDbContext _db;
        public CommendeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public string webRoutPath => throw new NotImplementedException();

        public async Task<CommandeModel> Create(CommandeModel commende)
        {
            _db.Commendes.Add(commende);
            await _db.SaveChangesAsync();
            return commende;
        }

        public async Task Delete(Guid id)
        {
            var commendeDelet = await _db.Commendes.FindAsync(id);
            _db.Commendes.Remove(commendeDelet);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommandeModel>> Get()
        {
            var commendesLits = await _db.Commendes.ToListAsync();
            return commendesLits;
        }

        public async Task<CommandeModel> Get(Guid id)
        {
            return await _db.Commendes.FindAsync(id);
        }

        public  async Task Update(CommandeModel commande)
        {
            _db.Entry(commande).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
