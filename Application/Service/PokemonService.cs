﻿using Application.Repository;
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
