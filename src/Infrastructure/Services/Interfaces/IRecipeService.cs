using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using Infrastructure.DTO;

namespace Infrastructure.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> GetAsync(Guid id);
        Task CreateAsync(Guid id,string name,ISet<Ingredient> ingredients);
        Task UpdateAsync(Guid id, string name,ISet<Ingredient> ingredients);
        Task DeleteAsync(Guid id);
    }
}