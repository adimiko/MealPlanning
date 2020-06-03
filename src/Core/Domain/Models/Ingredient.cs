using System;
using Core.Extensions;

namespace Core.Domain.Models
{
    public class Ingredient : Entity
    {
        public int Value {get; protected set;}
        public IngredientInfo IngredientInfo {get; protected set;}
        public NutritionInfo NutritionInfo {get; protected set;}

        protected Ingredient() {}

        public Ingredient(Guid id, int value,IngredientInfo ingredientInfo)
        {
            SetId(id);
            SetValue(value);
            SetIngredientInfo(ingredientInfo);
        }

        public void SetIngredientInfo(IngredientInfo ingredientInfo)
        {
            _= ingredientInfo != null ? IngredientInfo = ingredientInfo : throw new Exception("IngredientInfo must not be null.");
            UpdateNutritionInfo();
        }

        public void SetValue(int value)
        => _= value.IsGreaterThanZero() ? Value = value : throw new Exception("Value have to be greater than zero.");

        private void SetId(Guid id)
        => _= id.IsNotEmpty() ? Id = id : throw new Exception("Id must not be empty.");

        public void UpdateNutritionInfo()
        {
            float fat = (float)(Value/100f) * IngredientInfo.NutritionInfoPerHundredGrams.Fat;
            float carbohydrate = (float)(Value/100f) * IngredientInfo.NutritionInfoPerHundredGrams.Carbohydrate;
            float protein = (float)(Value/100f) * IngredientInfo.NutritionInfoPerHundredGrams.Protein;

            NutritionInfo = new NutritionInfo(fat,carbohydrate,protein);
        } 
    }
}