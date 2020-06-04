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
            new IngredientInfo(Guid.NewGuid(),"Ser","g","produkt spożywczy wytwarzany poprzez wytrącenie z mleka tłuszczu i białka w postaci skrzepu, który zostaje poddany dalszej obróbce.",new NutritionInfo(32f,4f,18f)),
            new IngredientInfo(Guid.NewGuid(),"Mleko","g","Wydzielina gruczołu mlekowego samic ssaków, pojawiająca się w okresie laktacji.",new NutritionInfo(10f,10f,5f)),
            new IngredientInfo(Guid.NewGuid(),"Schab","g","Schab to kawałek mięsa od świni, utworzony z tkanki wzdłuż grzbietowej strony klatki piersiowej. Jako produkt żywnościowy dla człowieka najczęstsze zastosowanie ma mleko krowie.",new NutritionInfo(1f,5f,3f)),
            new IngredientInfo(Guid.NewGuid(),"Jajko","g","Jaja jako bogate źródło substancji odżywczych są podstawą wielu potraw.",new NutritionInfo(11f,1f,13f)),
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