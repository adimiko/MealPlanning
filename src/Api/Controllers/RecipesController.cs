using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.Models;
using Infrastructure.Commands.Ingredients;
using Infrastructure.Commands.Recipes;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        => Json(await _recipeService.GetAsync(id));

        [HttpGet]
        public async Task<IActionResult> Browse()
        => Json(await _recipeService.BrowseAsync());
        
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRecipe command)
        {
            command.Id = Guid.NewGuid();

            ISet<Ingredient> Ingredients = new HashSet<Ingredient>();

            foreach(var c in command.Ingredients)
            {
                Ingredients.Add(new Ingredient(c.Id,c.Name,_mapper.Map<NutritionInfo>(c.NutritionInfo),c.Unit));
            }

            await _recipeService.CreateAsync
            (
                command.Id,
                command.Name,
                Ingredients
            );
            return Created($"/recipes/{command.Id}",null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateRecipe command)
        {
            ISet<Ingredient> Ingredients = new HashSet<Ingredient>();

            foreach(var c in command.Ingredients)
            {
                Ingredients.Add(new Ingredient(c.Id,c.Name,c.NutritionInfo,c.Unit));
            }

            await _recipeService.UpdateAsync(id,command.Name,Ingredients);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _recipeService.DeleteAsync(id);
            return NoContent();
        }
    }
}