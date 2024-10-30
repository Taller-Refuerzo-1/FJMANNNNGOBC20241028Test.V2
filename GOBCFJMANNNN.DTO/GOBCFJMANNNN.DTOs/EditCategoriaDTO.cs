using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GOBCFJMANNNN.DTO.GOBCFJMANNNN.DTOs
{
    public class EditCategoriaDTO
    {
        public EditCategoriaDTO(GetIdResultCategoriaDTO get)
        {
            Id = get.Id;
            Nombre = get.Nombre;
        }

        //Constructo vacio
        public EditCategoriaDTO()
        {
        }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de 30 caracteres")]
        public string Nombre { get; set; }
    }
}
