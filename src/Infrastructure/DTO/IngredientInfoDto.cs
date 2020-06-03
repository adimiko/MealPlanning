using System;
using Core.Domain.Models;

namespace Infrastructure.DTO
{
    public class IngredientInfoDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
    }
}