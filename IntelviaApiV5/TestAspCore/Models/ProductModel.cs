using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Authentication;

namespace TestAspCore.Models
{
    public class ProductModel
    {
        [Key]
        public Guid id { get; set; }
      
        public virtual ICollection<CommendProduct> Commends { get; set; }
        public Guid Catgo_id { get; set; }

        [ForeignKey("Catgo_id")]
        public CategorieModel Categories { get; set; }

        public string Nom { get; set; }
        public float prix{ get; set; }
        public string description { get; set; }
        public int QStock { get; set; }

        public string ImageName { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
