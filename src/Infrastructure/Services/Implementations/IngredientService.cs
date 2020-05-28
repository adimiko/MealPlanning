using System;
using System.Threading.Tasks;
using Core.Domain;
using Core.Repositories;
using Infrastructure.Services.Interfaces;
using Infrastructure.Extensions;

namespace Infrastructure.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task<Ingredient> GetAsync(Guid id)
        => await _ingredientRepository.GetOrFailAsync(id);
        public async Task CreateAsync(Guid id, string name, NutritionInfo nutritionInfo, string unit)
        {
            var ingredient = await _ingredientRepository.GetOrFailAsync(id);

            if(ingredient != null)
            {
                throw new Exception($"Ingredient with id '{id}' already exists.");
            }

            ingredient = new Ingredient(id,name,nutritionInfo,unit);

            await _ingredientRepository.AddAsync(ingredient);
        }
        public async Task UpdateAsync(Guid id, string name, NutritionInfo nutritionInfo, string unit)
        {
            var ingredient = await _ingredientRepository.GetOrFailAsync(id);

            if(ingredient == null)
            {
                throw new Exception($"Ingredient with id '{id}' does not exist.");
            }

            ingredient.SetName(name);
            ingredient.SetNutritionInfo(nutritionInfo);
            ingredient.SetUnit(unit);

            await _ingredientRepository.UpdateAsync(ingredient);
        }

        public async Task DeleteAsync(Guid id)
        {
            var ingredient = await _ingredientRepository.GetOrFailAsync(id);

            if(ingredient == null)
            {
                throw new Exception($"Ingredient with id '{id}' does not exist.");
            }

            await _ingredientRepository.DeleteAsync(ingredient);
        }
    }
}