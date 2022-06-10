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
    public class PokemonService
    {
        private readonly PokemonRepository _pokemonRepository; 
        public PokemonService(ApplicationContext dbContext)
        {
            _pokemonRepository = new(dbContext);
        }
        public async Task Add(SavePokemonViewModel spvm)
        {
            Pokemon pokemon = new();
            pokemon.Name = spvm.Name;
            pokemon.ImageUrl = spvm.ImageUrl;
            pokemon.TipoPriId = spvm.TipoPriId;
            pokemon.TipoSecId = spvm.TipoSecId;
            pokemon.RegionId = spvm.RegionId;
            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task Update(SavePokemonViewModel spvm)
        {
            Pokemon pokemon = new();
            pokemon.Name = spvm.Name;
            pokemon.Id = spvm.Id;
            pokemon.ImageUrl = spvm.ImageUrl;
            pokemon.TipoPriId = spvm.TipoPriId;
            pokemon.TipoSecId = spvm.TipoSecId;
            pokemon.RegionId = spvm.RegionId;
            await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> GetByIdSaveViewModel(int Id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(Id);
            SavePokemonViewModel spvm = new();
            spvm.Name = pokemon.Name;
            spvm.Id = pokemon.Id;
            spvm.ImageUrl = pokemon.ImageUrl;
            spvm.TipoPriId = pokemon.TipoPriId;
            spvm.TipoSecId = pokemon.TipoSecId;
            spvm.RegionId = pokemon.RegionId;

            return spvm;
        }

        public async Task Delete(int Id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(Id);
            await _pokemonRepository.DeleteAsync(pokemon);

        }
        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonViewModel
            {
               Name=pokemon.Name,
               ImageUrl=pokemon.ImageUrl,
               Id=pokemon.Id
               
            }).ToList();
        }
    }
}
