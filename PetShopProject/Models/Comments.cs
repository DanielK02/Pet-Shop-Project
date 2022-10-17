using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("AnimalId")]
        public int AnimalId { get; set; }
        public string Comment { get; set; }
    }
}
