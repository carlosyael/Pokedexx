using Application.Service;
using Application.ViewModels;
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
        private readonly RegionService _regionService;
        public LRegion regiones = LRegion.getInstace();
        private readonly TipoService _tipoService;
        public LTipo tipos = LTipo.getInstace();

        public HomeController(ApplicationContext dbContext)
        {
            _regionService = new(dbContext);
            _pokemonService = new(dbContext);
            _tipoService = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            tipos.Tipos = await _tipoService.GetAllViewModel();
            regiones.regiones = await _regionService.GetAllViewModel();
            return View(await _pokemonService.GetAllViewModel());
        }


    }
}
