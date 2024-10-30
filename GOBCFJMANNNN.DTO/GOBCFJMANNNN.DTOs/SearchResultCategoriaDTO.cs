using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOBCFJMANNNN.DTO.GOBCFJMANNNN.DTOs
{
    public class SearchResultCategoriaDTO
    {
        public int CountRow { get; set; }
        public List<CategoriaDTO> Data { get; set; }
        public class CategoriaDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Nombre{ get; set; }
        }
    }
}
