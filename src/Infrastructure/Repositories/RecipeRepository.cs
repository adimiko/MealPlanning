using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private static ISet<Recipe> _recipes = new HashSet<Recipe>()
        {

        };
        public async Task<Recipe> GetAsync(Guid id)
        => await Task.FromResult(_recipes.Where(x => x.Id == id).SingleOrDefault());

        public async Task UpdateAsync(Recipe recipe)
        {
            await Task.CompletedTask;
        }
        public async Task AddAsync(Recipe recipe)
        {
            _recipes.Add(recipe);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Recipe recipe)
        {
            _recipes.Remove(recipe);
            await Task.CompletedTask;
        }
    }
}