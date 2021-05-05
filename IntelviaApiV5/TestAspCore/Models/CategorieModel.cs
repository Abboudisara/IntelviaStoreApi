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

        [Required(ErrorMessage = "The Nom field is required !")]
        public string Nom { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public virtual ICollection<ProductModel> products { get; set; }

    }
}
