using System;
using System.Threading.Tasks;
using AutoMapper;
using Core.Domain.Models;
using Infrastructure.Commands.IngredientsInfo;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientsInfoController : Controller
    {
        private readonly IIngredientInfoService _ingredientInfoService;
        private readonly IMapper _mapper;

        public IngredientsInfoController(IIngredientInfoService ingredientInfoService, IMapper mapper)
        {
            _ingredientInfoService = ingredientInfoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        => Json(await _ingredientInfoService.GetAsync(id));

        [HttpGet]
        public async Task<IActionResult> Browse()
        => Json(await _ingredientInfoService.BrowseAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateIngredientsInfo command)
        {
            command.Id = Guid.NewGuid();

            await _ingredientInfoService.CreateAsync
            (
                command.Id,
                command.Name,
                command.Unit,
                command.Description,
                _mapper.Map<NutritionInfo>(command.NutritionInfoPerHundredGrams)
            );
            return Created($"/IngredientsInfo/{command.Id}",null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateIngredientsInfo command)
        {
            await _ingredientInfoService.UpdateAsync
            (
                id,
                command.Name,
                command.Unit,
                command.Description,
                _mapper.Map<NutritionInfo>(command.NutritionInfoPerHundredGrams)
            );
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ingredientInfoService.DeleteAsync(id);
            return NoContent();
        }
    }
}