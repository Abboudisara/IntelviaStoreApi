using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;

namespace TestAspCore.Repositories
{
    public  interface IStoreRepository<TEntity>
    {
        string webRoutPath { get; }

        Task<IEnumerable<TEntity>> Get();
        Task <TEntity> Get(Guid id);
        Task<TEntity> Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);
    }
}
