using System;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Repositories
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetAsync(Guid id);
        Task AddAsync(Ingredient ingredient);
        Task UpdateAsync(Ingredient ingredient);
        Task DeleteAsync(Ingredient ingredient);
    }
}