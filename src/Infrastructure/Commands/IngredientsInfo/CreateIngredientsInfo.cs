using System;
using Infrastructure.Commands.NutritionInfos;

namespace Infrastructure.Commands.IngredientsInfo
{
    public class CreateIngredientsInfo
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Unit {get; set;}
        public string Description {get; set;}
        public CreateAndUpdateNutritionInfo NutritionInfoPerHundredGrams {get; set;}
    }
}