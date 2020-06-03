using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class IngredientInfoRepository : IIngredientInfoRepository
    {
        private static ISet<IngredientInfo> _ingredientsInfo = new HashSet<IngredientInfo>()
        {
            new IngredientInfo(Guid.NewGuid(),"Ser żółty","g","Ser żółty powstaje z krowiego mleka.",new NutritionInfo(30f,20f,26f)),
            new IngredientInfo(Guid.NewGuid(),"Mleko krowie","ml","Mleko krowie podchodzi od krów.",new NutritionInfo(10f,10f,5f)),
            new IngredientInfo(Guid.NewGuid(),"Szynka wieprzowa","ml","Szynka wieprzowa pochodzi od wieprza",new NutritionInfo(20f,10f,27f)),
        };
        public async Task<IngredientInfo> GetAsync(Guid id)
        => await Task.FromResult(_ingredientsInfo.Where(x => x.Id == id).SingleOrDefault());
        public async Task<IEnumerable<IngredientInfo>> BrowseAsync()
        => await Task.FromResult(_ingredientsInfo.AsEnumerable());
        public async Task AddAsync(IngredientInfo ingredientInfo)
        {
            _ingredientsInfo.Add(ingredientInfo);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(IngredientInfo ingredientInfo)
        => await Task.CompletedTask;

        public async Task DeleteAsync(IngredientInfo ingredientInfo)
        {
            _ingredientsInfo.Remove(ingredientInfo);
            await Task.CompletedTask;
        }
    }
}