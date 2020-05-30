using AutoMapper;
using Core.Domain.Models;
using Infrastructure.Commands.NutritionInfos;
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

            cfg.CreateMap<CreateAndUpdateNutritionInfo,NutritionInfo>()
            .ConstructUsing(x => new NutritionInfo(x.Fat,x.Carbohydrate,x.Protein));

         }).CreateMapper();
    }
}