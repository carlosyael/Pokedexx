using Application.Repository;
using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PokemonViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int RegionId { get; set; }

        public int TipoPriId { get; set; } 

        public int TipoSecId { get; set; }

        public LRegion regions = LRegion.getInstace();
        public LTipo tipos = LTipo.getInstace();

    }
}
