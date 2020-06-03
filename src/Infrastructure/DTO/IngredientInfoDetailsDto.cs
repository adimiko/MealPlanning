using System;
using Core.Domain.Models;

namespace Infrastructure.DTO
{
    public class IngredientInfoDetailsDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Unit {get; set;}
        public string Description {get; set;}
        public NutritionInfo NutritionInfoPerHundredGrams {get; set;}
    }
}