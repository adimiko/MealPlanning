using System;
using Core.Domain.Models;
using Infrastructure.Commands.NutritionInfos;

namespace Infrastructure.Commands.Ingredients
{
    public class CreateIngredient
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public CreateAndUpdateNutritionInfo NutritionInfo {get; set;}
        public string Unit {get; set;}
    }
}