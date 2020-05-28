using System;
using System.Collections;
using System.Collections.Generic;
using Core.Domain;

namespace Infrastructure.DTO
{
    public class RecipeDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public NutritionInfoDto NutritionInfo {get; set;}
        public IEnumerable<IngredientDto> Ingredients {get; set;}
    }
}