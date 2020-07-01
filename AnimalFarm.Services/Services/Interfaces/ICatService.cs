using AnimalFarm.Domain.Models;
using System.Collections.Generic;

namespace AnimalFarm.Services.Services.Interfaces
{
    public interface ICatService
    {
        void Insert(Cat cat);
        Cat Get(int id);
        IEnumerable<Cat> GetAll();
    }
}