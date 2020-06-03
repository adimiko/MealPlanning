using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private static ISet<Recipe> _recipes = new HashSet<Recipe>()
        {
            new Recipe(Guid.NewGuid(),"Przepis na jajecznice",
            new HashSet<Ingredient>()
            {
                new Ingredient(Guid.NewGuid(),10,
                new IngredientInfo(Guid.NewGuid(),"Jajko","g","Jajka kurze", new NutritionInfo(10,10,10)))
            }
            )
        };
        public async Task<Recipe> GetAsync(Guid id)
        => await Task.FromResult(_recipes.Where(x => x.Id == id).SingleOrDefault());
        public async Task<IEnumerable<Recipe>> BrowseAsync()
        => await Task.FromResult(_recipes.AsEnumerable());
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