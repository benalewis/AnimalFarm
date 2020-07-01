using System.Collections.Generic;

namespace AnimalFarm.DTO.Models
{
    public class FarmDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CatDto> Cats { get; set; }
    }
}