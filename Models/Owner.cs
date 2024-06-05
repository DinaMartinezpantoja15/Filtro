using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Filtro.Models
{
    public class Owner
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
         [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string? Names { get; set; }


         [Required(ErrorMessage = "El nombre es obligatorio.")]
         [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
         public string? LastNames { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido.")]

         public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Formato de teléfono inválido.")]
         public string? Phone { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(100, ErrorMessage = "La dirección no puede tener más de 100 caracteres.")]
         public string? Address { get; set; }


        [JsonIgnore]
        public ICollection<Pet> Pets { get; set; }
    }
    
    }
