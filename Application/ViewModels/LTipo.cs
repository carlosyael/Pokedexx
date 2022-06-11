using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LTipo
    {
        public List<TipoViewModel> Tipos = new();
        static private LTipo Instance;
        private LTipo() { }

        static public LTipo getInstace()
        {
            if (Instance == null)
            {
                Instance = new();
            }
            return Instance;
        }




    }
}
