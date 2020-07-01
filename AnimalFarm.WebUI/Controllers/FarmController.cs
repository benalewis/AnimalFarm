using AnimalFarm.DTO.Mapping;
using AnimalFarm.DTO.Models;
using AnimalFarm.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnimalFarm.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmController : Controller
    {
        private readonly ILogger<FarmController> _logger;
        private readonly IFarmService _farmService;

        public FarmController(ILogger<FarmController> logger, IFarmService farmService)
        {
            _logger = logger;
            _farmService = farmService;
        }

        [HttpGet]
        public string Index()
        {
            return "Farm controller";
        }

        [HttpPost]
        public string Create([FromBody] FarmDto farmDto)
        {
            _farmService.Create(farmDto.Map());

            return "Created";
        }

        [HttpDelete]
        public string Delete()
        {
            _farmService.ClearAnimals();

            return "Deleted";
        }
    }
}