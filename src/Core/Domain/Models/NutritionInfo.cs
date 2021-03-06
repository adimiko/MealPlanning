using System;
using Core.Extensions;

namespace Core.Domain.Models
{
    public class NutritionInfo
    {
        public float Fat {get; protected set;}
        public float Carbohydrate {get; protected set;}
        public float Protein {get; protected set;}
        public int Calories => (int)Math.Round((Fat * FatEnergyPerGram()) + (Carbohydrate * CarbohydrateEnergyPerGram()) + (Protein * ProteinEnergyPerGram()),0);
        protected NutritionInfo(){}
        public NutritionInfo(float fat,float carbohydrate,float protein)
        {
            SetFat(fat);
            SetCarbohydrate(carbohydrate);
            SetProtein(protein);
        }
        public void SetFat(float fat)
        => _= fat.IsEqualOrAboveZero()? Fat = (float)Math.Round(fat) : throw new Exception("Fat value have to equal or above zero.");

        public void SetCarbohydrate(float carbohydrate)
        => _= carbohydrate.IsEqualOrAboveZero()? Carbohydrate = (float)Math.Round(carbohydrate) : throw new Exception("Carbohydrate value have to equal or above zero.");

        public void SetProtein(float protein)
        => _= protein.IsEqualOrAboveZero()? Protein = (float)Math.Round(protein) : throw new Exception("Protein value have to equal or above zero.");

        public static int FatEnergyPerGram() => 9;
        public static int CarbohydrateEnergyPerGram() => 4;
        public static int ProteinEnergyPerGram() => 4;
    }
}