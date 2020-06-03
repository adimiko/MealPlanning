using System;
using Core.Domain.Models;

namespace Infrastructure.DTO
{
    public class IngredientDto
    {
        public Guid Id {get; set;}
        public string Value {get; set;}
        public string Name {get; set;} //TODO zmapować w Automapper
    }
}