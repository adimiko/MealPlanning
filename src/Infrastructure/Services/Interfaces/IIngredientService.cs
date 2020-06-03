using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Models;
using Infrastructure.DTO;

namespace Infrastructure.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<IngredientDto> GetAsync(Guid id);
        Task<IEnumerable<IngredientDto>> BrowseAsync();
        Task CreateAsync(Guid id, int value,IngredientInfo ingredientInfo);
        Task UpdateAsync(Guid id, int value,IngredientInfo ingredientInfo);
        Task DeleteAsync(Guid id);
    }
}