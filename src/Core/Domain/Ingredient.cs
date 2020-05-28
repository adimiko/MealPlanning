using System;
using System.Collections.Generic;
using Core.Extensions;

namespace Core.Domain
{
    public class Ingredient : Entity
    {
        private static List<string> _units = new List<string>
        {
            "g", "ml"
        };
        public string Name {get; protected set;}
        public string Unit {get; protected set;}
        public NutritionInfo NutritionInfo {get; protected set;}
        protected Ingredient(){}
        public Ingredient(Guid id, string name, NutritionInfo nutritionInfo, string unit)
        {
            SetId(id);
            SetName(name);
            SetNutritionInfo(nutritionInfo);
            SetUnit(unit);
        }
        private void SetId(Guid id)
        => _= id.IsNotEmpty() ? Id = id : throw new Exception("Id must not be empty.");

        public void SetName(string name)
        => _= !string.IsNullOrWhiteSpace(name) ? Name = name : throw new Exception("Name must not be null or white space.");


         public void SetNutritionInfo(NutritionInfo nutritionInfo)
        => _= nutritionInfo != null ? NutritionInfo = nutritionInfo : throw new Exception("NutritionInfo must not be null.");
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