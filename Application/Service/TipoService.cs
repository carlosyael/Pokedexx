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
            var tipoList = await _tipoRepository.GetAllAsync();
            return tipoList.Select(tipo => new TipoViewModel
            {
                Name = tipo.Name,
                Id = tipo.Id

            }).ToList();
        }
        public async Task Add(SaveTipoViewModel stvm)
        {
            Tipo tipo = new();
            tipo.Name = stvm.Name;

            await _tipoRepository.AddAsync(tipo);
        }

        public async Task Update(SaveTipoViewModel stvm)
        {
            Tipo tipo = new();
            tipo.Name = stvm.Name;
            tipo.Id = stvm.Id;
            await _tipoRepository.UpdateAsync(tipo);
        }

        public async Task<SaveTipoViewModel> GetByIdSaveViewModel(int Id)
        {
            var tipo = await _tipoRepository.GetByIdAsync(Id);
            SaveTipoViewModel stvm = new();
            stvm.Name = tipo.Name;
            stvm.Id = tipo.Id;
            

            return stvm;
        }

        public async Task Delete(int Id)
        {
            var tipo = await _tipoRepository.GetByIdAsync(Id);
            await _tipoRepository.DeleteAsync(tipo);

        }

    }
}
