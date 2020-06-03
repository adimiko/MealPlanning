using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Models;
using Infrastructure.DTO;

namespace Infrastructure.Services.Interfaces
{
    public interface IIngredientInfoService
    {
        Task<IngredientInfoDetailsDto> GetAsync(Guid id);
        Task<IEnumerable<IngredientInfoDto>> BrowseAsync();
        Task CreateAsync(Guid id, string name, string unit, string description, NutritionInfo nutritionInfoPerHundredGrams);
        Task UpdateAsync(Guid id, string name, string unit,string description, NutritionInfo nutritionInfoPerHundredGrams);
        Task DeleteAsync(Guid id);
    }
}