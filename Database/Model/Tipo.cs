using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
   public class Tipo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Pokemon> PokemonsPri { get; set; }
        public ICollection<Pokemon> PokemonsSec { get; set; }
    }
}
