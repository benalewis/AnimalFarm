using AnimalFarm.DataAccess.Repositories.Interfaces;
using AnimalFarm.Domain.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AnimalFarm.DataAccess.Repositories
{
    public class CatRepository : RepositoryBase, ICatRepository
    {
        public CatRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public Cat Get(int id)
        {
            return Connection.Query<Cat>("select * from cat where id = @id", new { id }, Transaction).FirstOrDefault();
        }

        public IEnumerable<Cat> GetAll()
        {
            return Connection.Query<Cat>("select * from cat", Transaction);
        }

        public void Insert(Cat cat)
        {
            Connection.Query(@"insert into dbo.Cat (Id,
                                        Name,
                                        FarmId)
                                    values(@id, @name, @farmId);", new { cat.Id, cat.Name, cat.FarmId }, Transaction);
        }

        public void Clear()
        {
            Connection.Query("delete from dbo.Cat;", transaction: Transaction);
        }
    }
}
