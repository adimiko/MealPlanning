using AutoMapper;
using Core.Domain.Models;
using Infrastructure.DTO;

namespace Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        => new MapperConfiguration( cfg =>
         {
            cfg.CreateMap<Recipe,RecipeDto>();
            cfg.CreateMap<Ingredient,IngredientDto>();
            cfg.CreateMap<NutritionInfo,NutritionInfoDto>();
         }).CreateMapper();
    }
}