using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveRegionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Name { get; set; }

    }
}
