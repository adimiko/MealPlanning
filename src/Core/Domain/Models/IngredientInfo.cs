using System;
using System.Collections.Generic;
using Core.Extensions;

namespace Core.Domain.Models
{
    public class IngredientInfo : Entity
    {
        private static List<string> _units = new List<string>
        {
            "g", "ml"
        };
        public string Name {get; protected set;}
        public string Unit {get; protected set;}
        public string Description {get; protected set;}
        public NutritionInfo NutritionInfoPerHundredGrams {get; protected set;}
        protected IngredientInfo(){}
        public IngredientInfo(Guid id, string name, string unit,string description, NutritionInfo nutritionInfoPerHundredGrams)
        {
            SetId(id);
            SetName(name);
            SetDescription(description);
            SetUnit(unit);

            SetNutritionInfoPerHundredGrams(nutritionInfoPerHundredGrams);
        }
        private void SetId(Guid id)
        => _= id.IsNotEmpty() ? Id = id : throw new Exception("Id must not be empty.");

        public void SetName(string name)
        => _= !string.IsNullOrWhiteSpace(name) ? Name = name : throw new Exception("Name must not be null or white space.");

        public void SetDescription(string description)
        => _= !string.IsNullOrWhiteSpace(description) ? Description = description : throw new Exception("Description must not be null or white space.");
        public void SetNutritionInfoPerHundredGrams(NutritionInfo nutritionInfoPerHundredGrams)
        => _= nutritionInfoPerHundredGrams != null ? NutritionInfoPerHundredGrams = nutritionInfoPerHundredGrams : throw new Exception("NutritionInfo must not be null.");
        public void SetUnit(string unit)
        {
            foreach(var _unit in _units)
            {
                if(_unit == unit.ToLowerInvariant())
                {
                    Unit = unit.ToLowerInvariant();
                    return;
                }
            }

            throw new Exception("The given unit is bad.");
        }
    }
}