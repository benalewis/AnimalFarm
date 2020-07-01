using AnimalFarm.Domain.Models;
using AnimalFarm.DTO.Models;
using System.Linq;

namespace AnimalFarm.DTO.Mapping
{
    public static class FarmMapping
    {
        public static Farm Map(this FarmDto farmDto)
        {
            return new Farm(farmDto.Id, farmDto.Name, farmDto.Cats?.Select(x => x.Map()).ToList());
        }

        public static FarmDto ReverseMap(this Farm farm)
        {
            return new FarmDto
            {
                Id = farm.Id,
                Name = farm.Name,
                Cats = farm.Cats?.Select(x => x.ReverseMap())
            };
        }
    }
}
