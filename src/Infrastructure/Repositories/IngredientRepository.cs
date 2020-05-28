using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private static ISet<Ingredient> _ingredients = new HashSet<Ingredient>()
        {
            
        };
        public async Task<Ingredient> GetAsync(Guid id)
        => await Task.FromResult(_ingredients.Where(x => x.Id == id).SingleOrDefault());
        public async Task AddAsync(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Ingredient ingredient)
        {
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(Ingredient ingredient)
        {
            _ingredients.Remove(ingredient);
            await Task.CompletedTask;
        }
    }
}