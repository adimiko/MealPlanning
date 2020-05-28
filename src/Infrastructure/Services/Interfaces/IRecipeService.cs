using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;

namespace Infrastructure.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<Recipe> GetAsync(Guid id);
        Task CreateAsync(Guid id,string name,ISet<Ingredient> ingredients);
        Task UpdateAsync(Guid id, string name,ISet<Ingredient> ingredients);
        Task DeleteAsync(Guid id);
    }
}