using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Repositories
{
    public interface IIngredientInfoRepository
    {
         Task<IngredientInfo> GetAsync(Guid id);
        Task<IEnumerable<IngredientInfo>> BrowseAsync();
        Task AddAsync(IngredientInfo ingredientInfo);
        Task UpdateAsync(IngredientInfo ingredientInfo);
        Task DeleteAsync(IngredientInfo ingredientInfo);
    }
}