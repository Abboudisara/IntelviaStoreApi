using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Models
{
    public class Product
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string type { get; set; }
        public double prix { get; set; }
    }
}
