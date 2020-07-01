using AnimalFarm.Domain.Models;
using AnimalFarm.Services.Services.Interfaces;
using AnimalFarm.Services.UnitOfWork.Interfaces;

namespace AnimalFarm.Services.Services
{
    public class FarmService : IFarmService
    {
        private readonly IDapperUnitOfWork UnitOfWork;

        public FarmService(IDapperUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void ClearAnimals()
        {
            UnitOfWork.CatRepository.Clear();
            UnitOfWork.FarmRepository.Clear();

            UnitOfWork.Commit();
        }

        public void Create(Farm farm)
        {
            UnitOfWork.FarmRepository.Create(farm);

            UnitOfWork.Commit();
        }
    }
}
