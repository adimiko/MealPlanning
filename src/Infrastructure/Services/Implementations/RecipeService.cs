using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.Models;
using Core.Repositories;
using Infrastructure.DTO;
using Infrastructure.Extensions;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        
        public RecipeService(IRecipeRepository recipeRepository,IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<RecipeDto> GetAsync(Guid id)
        => _mapper.Map<RecipeDto>(await _recipeRepository.GetOrFailAsync(id));

        public async Task CreateAsync(Guid id, string name, ISet<Ingredient> ingredients)
        {
            var recipe = await _recipeRepository.GetOrFailAsync(id);

            if(recipe != null)
            {
                throw new Exception($"Recipe with id '{id}' alredy exists.");
            }

            recipe = new Recipe(id,name,ingredients);

            await _recipeRepository.AddAsync(recipe);
        }
        public async Task UpdateAsync(Guid id, string name, ISet<Ingredient> ingredients)
        {
            var recipe = await _recipeRepository.GetOrFailAsync(id);

            if(recipe == null)
            {
                throw new Exception($"Recipe with id '{id}' does not exist.");
            }
            recipe.SetName(name);
            recipe.SetIngredients(ingredients);
            await _recipeRepository.UpdateAsync(recipe);
        }
        public async Task DeleteAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetOrFailAsync(id);

            if(recipe == null)
            {
                throw new Exception($"Recipe with id '{id}' does not exist.");
            }

            await _recipeRepository.DeleteAsync(recipe);
        }
    }
}