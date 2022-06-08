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

    }
}
