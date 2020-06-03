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
    public class IngredientInfoService : IIngredientInfoService
    {

        private readonly IIngredientInfoRepository _ingredientInfoRepository;
        private readonly IMapper _mapper; 

        public IngredientInfoService(IIngredientInfoRepository ingredientInfoRepository, IMapper mapper)
        {
            _ingredientInfoRepository = ingredientInfoRepository;
            _mapper = mapper;
        }
        public async Task<IngredientInfoDetailsDto> GetAsync(Guid id)
        => _mapper.Map<IngredientInfoDetailsDto>(await _ingredientInfoRepository.GetOrFailAsync(id));
        public async Task<IEnumerable<IngredientInfoDto>> BrowseAsync()
        => _mapper.Map<IEnumerable<IngredientInfoDto>>(await _ingredientInfoRepository.BrowseAsync());

        public async Task CreateAsync(Guid id, string name, string unit, string description, NutritionInfo nutritionInfoPerHundredGrams)
        {
            var ingredientInfo  = await _ingredientInfoRepository.GetAsync(id);

            if(ingredientInfo != null)
            {
                throw new Exception($"IngredientInfo with id '{id}' already exists.");
            }

            ingredientInfo = new IngredientInfo(id,name,unit,description,nutritionInfoPerHundredGrams);
            await _ingredientInfoRepository.AddAsync(ingredientInfo);
        }
        public async Task UpdateAsync(Guid id, string name, string unit, string description, NutritionInfo nutritionInfoPerHundredGrams)
        {
            var ingredientInfo = await _ingredientInfoRepository.GetOrFailAsync(id);

            ingredientInfo.SetName(name);
            ingredientInfo.SetUnit(unit);
            ingredientInfo.SetDescription(description);
            ingredientInfo.SetNutritionInfoPerHundredGrams(nutritionInfoPerHundredGrams);

            await _ingredientInfoRepository.UpdateAsync(ingredientInfo);
        }
        public async Task DeleteAsync(Guid id)
        {
            var ingredientInfo = await _ingredientInfoRepository.GetOrFailAsync(id);

            if(ingredientInfo == null)
            {
                throw new Exception($"IngredientInfo with id '{id}' does not exist.");
            }

            await _ingredientInfoRepository.DeleteAsync(ingredientInfo);
        }
    }
}