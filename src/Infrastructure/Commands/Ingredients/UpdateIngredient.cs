using Infrastructure.Commands.NutritionInfos;

namespace Infrastructure.Commands.Ingredients
{
    public class UpdateIngredients
    {
        public string Name {get; set;}
        public CreateAndUpdateNutritionInfo NutritionInfo {get; set;}
        public string Unit {get; set;}
    }
}