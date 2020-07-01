using AnimalFarm.Domain.Models;
using AnimalFarm.DTO.Models;

namespace AnimalFarm.DTO.Mapping
{
    public static class CatMapping
    {
        public static Cat Map(this CatDto cat)
        {
            return new Cat(cat.Id, cat.Name, cat.FarmId);
        }

        public static CatDto ReverseMap(this Cat cat)
        {
            return new CatDto
            {
                Id = cat.Id,
                Name = cat.Name,
                FarmId = cat.FarmId
            };
        }
    }
}