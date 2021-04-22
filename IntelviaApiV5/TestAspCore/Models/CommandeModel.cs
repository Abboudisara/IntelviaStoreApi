using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Authentication;

namespace TestAspCore.Models
{
    public class CommandeModel
    {
        [Key]
        public Guid id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string User_id { get; set; }

        [ForeignKey("User_id")]
        public ApplicationUser User { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }

    }
}
