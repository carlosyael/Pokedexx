using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int RegionId { get; set; }
        public int TipoPriId { get; set; }
        public int TipoSecId { get; set; }
        public Region Region { get; set; }
        public Tipo TipoPri { get; set; }
        public Tipo TipoSec { get; set; }
    }
}
