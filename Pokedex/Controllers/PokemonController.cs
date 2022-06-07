using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Pokmaint()
        {
            return View();
        }
    }
}
