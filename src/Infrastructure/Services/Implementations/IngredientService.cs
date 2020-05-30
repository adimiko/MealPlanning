using System;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Services.Interfaces;
using Infrastructure.Extensions;
using Infrastructure.DTO;
using AutoMapper;
using Core.Domain.Models;
using System.Collections.Generic;

namespace Infrastructure.Services.Implementations
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }
        public async Task<IngredientDto> GetAsync(Guid id)
        => _mapper.Map<IngredientDto>(await _ingredientRepository.GetOrFailAsync(id));

        public async Task<IEnumerable<IngredientDto>> BrowseAsync()
        => _mapper.Map<IEnumerable<IngredientDto>>(await _ingredientRepository.BrowseAsync());
        public async Task CreateAsync(Guid id, string name, NutritionInfo nutritionInfo, string unit)
        {
            var ingredient = await _ingredientRepository.GetAsync(id);

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