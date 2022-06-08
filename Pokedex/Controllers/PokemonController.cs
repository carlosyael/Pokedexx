using Application.Service;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
        }

        public async Task<IActionResult> Pokmant()
        {
            return View(await _pokemonService.GetAllViewModel());
        }
    }
}
