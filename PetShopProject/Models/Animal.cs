using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopProject.Models
{
    public class Animal
    {
        [Key][Required]
        public int AnimalId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 120)]
        [Required]
        public int? Age { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        [ForeignKey("CategoryId")]
        [Required]
        public int CategoryId { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }

    }
}
