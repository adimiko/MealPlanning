using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetAsync(Guid id);
        Task<IEnumerable<Recipe>> BrowseAsync();
        Task AddAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
        Task DeleteAsync(Recipe recipe);
    }
}