using System;

namespace Infrastructure.DTO
{
    public class IngredientDto
    {
        public Guid Id {get; set;}
        public string Name {get; protected set;}
        public string Unit {get; protected set;}
    }
}