using AnimalFarm.DataAccess.Repositories.Interfaces;
using AnimalFarm.Domain.Models;
using Dapper;
using System.Data;

namespace AnimalFarm.DataAccess.Repositories
{
    public class FarmRepository : RepositoryBase, IFarmRepository
    {
        public FarmRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public void Clear()
        {
            Connection.Query("delete from dbo.Farm;", transaction: Transaction);
        }

        public void Create(Farm farm)
        {
            Connection.Query(@"insert into dbo.Farm (
                Id,
                Name)
            values(@id, @name); ", new { @id = farm.Id, @name = farm.Name }, transaction: Transaction);
        }
    }
}