using System;
using System.Threading.Tasks;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        => Json(await _recipeService.GetAsync(id));
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _recipeService.DeleteAsync(id);
            return NoContent();
        }
    }
}