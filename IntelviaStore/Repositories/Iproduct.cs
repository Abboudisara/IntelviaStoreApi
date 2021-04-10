
using IntelviaStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntelviaStore.ProductData
{
   public  interface Iproduct
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(Guid id);
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(Guid id);


    }
}
