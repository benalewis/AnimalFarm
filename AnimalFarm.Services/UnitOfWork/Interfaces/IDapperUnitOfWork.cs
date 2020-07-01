using AnimalFarm.DataAccess.Repositories.Interfaces;
using System;

namespace AnimalFarm.Services.UnitOfWork.Interfaces
{
    public interface IDapperUnitOfWork : IDisposable
    {
        ICatRepository CatRepository { get; }
        IFarmRepository FarmRepository { get; }

        void Commit();
    }
}
