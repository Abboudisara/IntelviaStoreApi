using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspCore.Models
{
    public class CategorieModel
    {
        [Key]
        public Guid id { get; set; }
        public string Nom { get; set; }
        
        public string ImageName { get; set; }

        [NotMapped]
        public string SourceImage { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public virtual ICollection<ProductModel> products { get; set; }

    }
}
