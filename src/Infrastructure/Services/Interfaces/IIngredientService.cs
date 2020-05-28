using System;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<IngredientDto> GetAsync(Guid id);
        Task CreateAsync(Guid id, string name, NutritionInfo nutritionInfo, string unit);
        Task UpdateAsync(Guid id, string name, NutritionInfo nutritionInfo, string unit);
        Task DeleteAsync(Guid id);
    }
}