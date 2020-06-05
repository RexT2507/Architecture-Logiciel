using ApiLibrary.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Models
{
    public class Product : BaseEntity
    {
        public int ID { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

    }
}
