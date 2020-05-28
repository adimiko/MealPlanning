using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Recipe : Entity
    {
        private ISet<Ingredient> _ingredients = new HashSet<Ingredient>();
        public string Name {get; protected set;}
        public NutritionInfo NutritionInfo {get; protected set;}
        public IEnumerable Ingredients => _ingredients;
        
        protected Recipe(){}
        public Recipe(Guid id,string name,NutritionInfo nutritionInfo,ISet<Ingredient> ingredients)
        {
            SetId(id);
            SetName(name);
            SetNutritionInfo(nutritionInfo);
            SetIngredients(ingredients);
        }

        private void SetId(Guid id)
        => _= id != Guid.Empty? Id=id : throw new Exception("Id must not be empty.");

        public void SetName(string name)
        => _= !string.IsNullOrWhiteSpace(name)? Name = name : throw new Exception("Name must not be null or white space.");

        public void SetNutritionInfo(NutritionInfo nutritionInfo)
        {
            if(nutritionInfo == null)
            {
                throw new Exception("NutritionInfo must not be null.");
            }

            float fat = 0f;
            float carbohydrate = 0f;
            float protein = 0f;

            foreach(var ingredient in _ingredients)
            {
                fat += ingredient.NutritionInfo.Fat;
                carbohydrate += ingredient.NutritionInfo.Carbohydrate;
                protein += ingredient.NutritionInfo.Protein;
            }

            NutritionInfo = new NutritionInfo(fat,carbohydrate,protein);
        } 

        public void SetIngredients(ISet<Ingredient> ingredients)
        => _= ingredients != null ? _ingredients = ingredients : throw new Exception("Ingredients must not be null");
    }
}