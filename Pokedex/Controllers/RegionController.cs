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
    public class RegionController : Controller
    {
        private readonly RegionService _regionService;


        public RegionController(ApplicationContext dbContext)
        {
            _regionService = new(dbContext);
        }
        public async Task<IActionResult> Regionmant()
        {
            return View(await _regionService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegionViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel srvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", srvm);
            }
            await _regionService.Add(srvm);
            return RedirectToRoute(new { Controller = "Region", Action = "Regionmant" });
        }

        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveRegion", await _regionService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel srvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", srvm);
            }
            await _regionService.Update(srvm);
            return RedirectToRoute(new { Controller = "Region", Action = "Regionmant" });
        }

        public async Task<IActionResult> Delete(int Id)
        {

            await _regionService.Delete(Id);
            return RedirectToRoute(new { Controller = "Region", Action = "Regionmant" });
        }

    }
}
