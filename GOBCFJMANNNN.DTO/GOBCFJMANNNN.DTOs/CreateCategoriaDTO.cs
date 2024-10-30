using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOBCFJMANNNN.DTO.GOBCFJMANNNN.DTOs
{
    public class CreateCategoriaDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo no puede contener mas de 50 caracteres")]
        public string Nombre { get; set; }
    }
}
