using Application.Service;
using Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
   public class SavePokemonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El Nombre es requerido")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "La Region es requerida")]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "El Tipo principal es requerido")]
        public int TipoPriId { get; set; }
        public int TipoSecId { get; set; }

        public LRegion regions = LRegion.getInstace();
        public LTipo tipos = LTipo.getInstace();
    }
}
