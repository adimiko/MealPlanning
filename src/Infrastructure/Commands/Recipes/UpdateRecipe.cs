using System.Collections.Generic;
using Core.Domain.Models;

namespace Infrastructure.Commands.Recipes
{
    public class UpdateRecipe
    {
        public string Name {get; set;}
        public ISet<Ingredient> Ingredients {get; set;}
    }
}