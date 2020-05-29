using System;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Repositories;

namespace Infrastructure.Extensions
{
    public static class RepositoryExtensionMethods
    {
        public static async Task<Recipe> GetOrFailAsync(this IRecipeRepository repository,Guid id)
        {
            var recipe = await repository.GetAsync(id);
            if(recipe != null) return recipe;

            throw new Exception($"Recipe with id '{id}' does not exist.");
        }

        public static async Task<Ingredient> GetOrFailAsync(this IIngredientRepository repository,Guid id)
        {
            var ingredient = await repository.GetAsync(id);
            if(ingredient != null) return ingredient;

            throw new Exception($"Ingredient with id '{id}' does not exist.");
        }
    }
}