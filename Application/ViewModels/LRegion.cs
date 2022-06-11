using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LRegion
    {
       public List<RegionViewModel> regiones = new();
        static private LRegion Instance;
        private LRegion() { }

        static public LRegion getInstace()
        {
            if (Instance == null)
            {
                Instance = new();
            }
            return Instance;
        }

        


    }
}
