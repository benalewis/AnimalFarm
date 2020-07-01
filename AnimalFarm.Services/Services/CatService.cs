using AnimalFarm.Domain.Models;
using AnimalFarm.Services.Services.Interfaces;
using AnimalFarm.Services.UnitOfWork.Interfaces;
using System.Collections.Generic;

namespace AnimalFarm.Services.Services
{
    public class CatService : ICatService
    {
        private readonly IDapperUnitOfWork UnitOfWork;

        public CatService(IDapperUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Cat Get(int id)
        {
            return UnitOfWork.CatRepository.Get(id);
        }

        public IEnumerable<Cat> GetAll()
        {
            return UnitOfWork.CatRepository.GetAll();
        }

        public void Insert(Cat cat)
        {
            UnitOfWork.CatRepository.Insert(cat);
            UnitOfWork.Commit();
        }
    }
}
