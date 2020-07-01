namespace AnimalFarm.Domain.Models
{
    public class Cat
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int? FarmId { get; private set; }

        public Cat(int id, string name, int? farmId)
        {
            Id = id;
            Name = name;
            FarmId = farmId;
        }
    }
}
