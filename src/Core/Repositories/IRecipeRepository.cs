using System;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetAsync(Guid id);
        Task AddAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
        Task DeleteAsync(Recipe recipe);
    }
}