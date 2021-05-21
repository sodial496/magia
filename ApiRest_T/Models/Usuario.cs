using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_T.Models
{
    public class Usuario
    {
        public int id { get; set; }
        
        [Required]
        [StringLength (20, ErrorMessage = "El nombre no debe contener mas de 20 caracteres")]
        [RegularExpression(@"^[a-zA-Z a-ñA-Ñ _]+$", ErrorMessage = "Nombre debe contener solo letras")]
        public string nombre { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El apellido no debe contener mas de 20 caracteres")]
        [RegularExpression(@"^[a-zA-Z a-ñA-Ñ _]+$", ErrorMessage = "Apellido debe contener solo letras")]
        public string apellido { get; set; }

        [Required]
        [Range (0, 9999999999, ErrorMessage = "La identificacion no debe contener mas de 10 digitos")]
        public int identificacion { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "La edad no debe contener mas de 2 digitos")]
        public int edad { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z a-ñA-Ñ _]+$", ErrorMessage = "La casa a la que aspira pertenecer debe contener solo letras")]
        public string casa { get; set; }
    }
}
