using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Filtro.Models
{
    public class Pet
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
         [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string? Name { get; set; }


         [Required(ErrorMessage = "El nombre es obligatorio.")]
         [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
         public string? Specie { get; set; }

        [Required(ErrorMessage = "la Raza  es obligatoria.")]
         public string? Race { get; set; }

    
        [Required(ErrorMessage = "la DateBirth es obligatorio.")]
        public DateTime? DateBirth { get; set; }

        
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
         public string? phone { get; set; }

        [Required(ErrorMessage = "El id_owner es obligatorio.")]
         public int? OwnerId { get; set; }
         public Owner Owner { get; set; }

        [JsonIgnore]
        public ICollection<Quote> Quotes { get; set; }

    }
}