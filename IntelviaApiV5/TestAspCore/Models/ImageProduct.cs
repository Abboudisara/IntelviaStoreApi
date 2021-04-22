using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspCore.Models
{
  
    public class ImageProduct
    {
        [Key]
        public Guid Id_image { get; set; }
        public Guid Product_Id { get; set; }

        [ForeignKey(nameof(Product_Id))]
        public ProductModel product { get; set; }

        [DisplayName("Upload Image")]
        public string Images { get; set; }

    }
}
