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
    public class TipoController : Controller
    {
        private readonly TipoService _tipoService;

        public TipoController(ApplicationContext dbContext)
        {
            _tipoService = new(dbContext);
        }

        public async Task<IActionResult> Tipomant()
        {
            return View(await _tipoService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveTipo", new SaveTipoViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveTipoViewModel stvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", stvm);
            }
            await _tipoService.Add(stvm);
            return RedirectToRoute(new { Controller = "Tipo", Action = "Tipomant" });
        }

        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveTipo", await _tipoService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveTipoViewModel stvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", stvm);
            }
            await _tipoService.Update(stvm);
            return RedirectToRoute(new { Controller = "Tipo", Action = "Tipomant" });
        }

        public async Task<IActionResult> Delete(int Id)
        {

            return View(await _tipoService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {

            await _tipoService.Delete(Id);
            return RedirectToRoute(new { Controller = "Tipo", Action = "Tipomant" });
        }
    }
}
