using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOBCFJMANNNN.DTO.GOBCFJMANNNN.DTOs
{
    public class SearchQueryCategoria
    {
        [Display(Name = "Nombre")]
        public string? Nombre_Like { get; set; }
    }
}
