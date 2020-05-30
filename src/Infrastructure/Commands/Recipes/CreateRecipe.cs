using System;
using System.Collections.Generic;
using Infrastructure.Commands.Ingredients;

namespace Infrastructure.Commands.Recipes
{
    public class CreateRecipe
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public ISet<CreateIngredient> Ingredients {get; set;}
    }
}