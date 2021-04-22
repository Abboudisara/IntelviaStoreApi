using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspCore.Models
{
    public class CommendProduct
    {

        [Key]
        public Guid Id { get; set; }
        public int Q_Commande { get; set; }
        public Guid CmdId { get; set; }
        [ForeignKey(nameof(CmdId))]
        public CommandeModel Commends{ get; set; }
       
        public Guid prdId { get; set; }

        [ForeignKey(nameof(prdId))]
        public ProductModel products { get; set; }



    }
}
