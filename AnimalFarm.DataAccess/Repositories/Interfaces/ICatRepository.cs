using AnimalFarm.Domain.Models;
using System.Collections.Generic;

namespace AnimalFarm.DataAccess.Repositories.Interfaces
{
    public interface ICatRepository
    {
        Cat Get(int id);
        IEnumerable<Cat> GetAll();
        void Insert(Cat cat);
        void Clear();
    }
}
