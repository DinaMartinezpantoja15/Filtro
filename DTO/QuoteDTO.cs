using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Filtro.DTO
{
    public class QuoteDTO
    {
        
        
        public int id { get; set; }
        [Required(ErrorMessage = "la DateBirth es obligatorio.")]
        public DateTime DATE { get; set; }

        [Required(ErrorMessage = "la Description es obligatorio.")]
        public string  Description { get; set; }

        [Required(ErrorMessage = "la Id de la Mascota  es obligatorio.")]
        public int PetId { get; set; }

        [Required(ErrorMessage = "la Id de la Veterinario  es obligatorio.")]
        public int VetId { get; set; }
       
        
    }
}