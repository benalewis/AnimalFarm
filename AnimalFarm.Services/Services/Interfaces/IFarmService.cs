using AnimalFarm.Domain.Models;

namespace AnimalFarm.Services.Services.Interfaces
{
    public interface IFarmService
    {
        void Create(Farm farm);
        void ClearAnimals();
    }
}