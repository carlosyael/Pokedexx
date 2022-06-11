using Application.Service;
using Application.ViewModels;
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
        private readonly RegionService _regionService;
        public LRegion regiones = LRegion.getInstace();
        private readonly TipoService _tipoService;
        public LTipo tipos = LTipo.getInstace();

        public PokemonController(ApplicationContext dbContext)
        {
            _pokemonService = new(dbContext);
            _regionService = new(dbContext);
            _tipoService = new(dbContext);
        }


        public async Task<IActionResult> Pokmant()
        {
            tipos.Tipos = await _tipoService.GetAllViewModel();
            regiones.regiones = await _regionService.GetAllViewModel();   
            return View(await _pokemonService.GetAllViewModel());
        }
        public IActionResult Create()
        {
            return View("SavePokemon", new SavePokemonViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel spvm)
        {
            tipos.Tipos = await _tipoService.GetAllViewModel();
            regiones.regiones = await _regionService.GetAllViewModel();
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", spvm);
            }
            await _pokemonService.Add(spvm);
            return RedirectToRoute(new { Controller = "Pokemon", Action = "Pokmant" });
        }

        public async Task<IActionResult> Edit(int Id)
        {
            tipos.Tipos = await _tipoService.GetAllViewModel();
            regiones.regiones = await _regionService.GetAllViewModel();
            return View("SavePokemon", await _pokemonService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel spvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon", spvm);
            }
            await _pokemonService.Update(spvm);
            return RedirectToRoute(new { Controller = "Pokemon", Action = "Pokmant" });
        }

        public async Task<IActionResult> Delete(int Id)
        {

            await _pokemonService.Delete(Id);
            return RedirectToRoute(new { Controller = "Pokemon", Action = "Pokmant" });
        }
    }
}
