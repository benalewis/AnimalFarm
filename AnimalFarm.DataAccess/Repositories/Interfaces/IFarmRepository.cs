using AnimalFarm.Domain.Models;

namespace AnimalFarm.DataAccess.Repositories.Interfaces
{
    public interface IFarmRepository
    {
        void Clear();

        void Create(Farm farm);
    }
}
