using Application.Service;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonService _pokemonService;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext); 
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonService.GetAllViewModel());
        }


    }
}
