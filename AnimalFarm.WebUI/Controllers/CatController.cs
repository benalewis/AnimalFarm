using AnimalFarm.DTO.Mapping;
using AnimalFarm.DTO.Models;
using AnimalFarm.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnimalFarm.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> _logger;
        private readonly ICatService _catService;

        public CatController(ILogger<CatController> logger, ICatService catService)
        {
            _logger = logger;
            _catService = catService;
        }

        [HttpGet]
        public string Index()
        {
            return "Cat controller";
        }

        // GET : cat/1
        [HttpGet("get/{id}")]
        public CatDto Get(int id)
        {
            var cat = _catService.Get(id);

            return cat.ReverseMap();
        }

        // POST : /
        [HttpPost()]
        public string Post([FromBody] CatDto cat)
        {
            var domainCat = cat.Map();

            _catService.Insert(domainCat);

            return "Inserted";
        }
    }
}
