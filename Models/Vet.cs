using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Filtro.Models
{
    public class Vet
    {
         public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
         [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string? Name { get; set; }

        
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string? Phone { get; set; }

        
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string? Address { get; set; }

        [JsonIgnore]
        public ICollection<Quote> Quotes { get; set; }

    }
}