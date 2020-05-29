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
            new Recipe(Guid.Parse("4593b72b-f4d4-44d8-9838-0ba449d35523"),"Omlet",
            new HashSet<Ingredient>()
            {
                new Ingredient(Guid.NewGuid(),"Jajka",new NutritionInfo(1,1,1),"g"),
                new Ingredient(Guid.NewGuid(),"Jogurt",new NutritionInfo(10,1,1),"g")
            }
            )
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