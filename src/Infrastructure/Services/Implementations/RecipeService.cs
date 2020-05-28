using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repositories;
using Infrastructure.Extensions;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        
        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<Recipe> GetAsync(Guid id)
        => await _recipeRepository.GetOrFailAsync(id);

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