using System.Collections.Generic;

namespace AnimalFarm.Domain.Models
{
    public class Farm
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<Cat> Cats { get; private set; }

        public Farm(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Farm(int id, string name, IEnumerable<Cat> cats)
        {
            Id = id;
            Name = name;
            Cats = cats;
        }
    }
}