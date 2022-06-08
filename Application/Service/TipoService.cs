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
    public class TipoService
    {
        private readonly TipoRepository _tipoRepository;
        public TipoService(ApplicationContext dbContext)
        {
            _tipoRepository = new(dbContext);
        }
        public async Task<List<TipoViewModel>> GetAllViewModel()
        {
            var regionList = await _tipoRepository.GetAllAsync();
            return regionList.Select(region => new TipoViewModel
            {
                Name = region.Name,
                Id = region.Id

            }).ToList();
        }
    }
}
