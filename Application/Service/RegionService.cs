using Application.Repository;
using Application.ViewModels;
using Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class RegionService
    {
        private readonly RegionRepository _regionRepository;
        public RegionService(ApplicationContext dbContext)
        {
            _regionRepository = new(dbContext);
        }
        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepository.GetAllAsync();
            return regionList.Select(region => new RegionViewModel
            {
                Name = region.Name,
                Id = region.Id

            }).ToList();
        }

        public async Task Add(SaveRegionViewModel srvm)
        {
            Region region = new();
            region.Name = srvm.Name;

            await _regionRepository.AddAsync(region);
        }

        public async Task Update(SaveRegionViewModel srvm)
        {
            Region region = new();
            region.Name = srvm.Name;
            region.Id = srvm.Id;
            await _regionRepository.UpdateAsync(region);
        }

        public async Task<SaveRegionViewModel> GetByIdSaveViewModel(int Id)
        {
            var region = await _regionRepository.GetByIdAsync(Id);
            SaveRegionViewModel srvm = new();
            srvm.Name = region.Name;
            srvm.Id = region.Id;


            return srvm;
        }

        public async Task Delete(int Id)
        {
            var region = await _regionRepository.GetByIdAsync(Id);
            await _regionRepository.DeleteAsync(region);

        }

    }
}
