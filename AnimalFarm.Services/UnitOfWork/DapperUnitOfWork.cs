using AnimalFarm.DataAccess.Repositories;
using AnimalFarm.DataAccess.Repositories.Interfaces;
using AnimalFarm.Services.UnitOfWork.Interfaces;
using System;
using System.Data;

namespace AnimalFarm.Services.UnitOfWork
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private ICatRepository _catRepository;
        private IFarmRepository _farmRepository;

        private bool _disposed = false;

        public ICatRepository CatRepository => _catRepository ?? (_catRepository = new CatRepository(_transaction));
        public IFarmRepository FarmRepository => _farmRepository ?? (_farmRepository = new FarmRepository(_transaction));

        public DapperUnitOfWork(IDbConnection dbConnection)
        {
            _connection = dbConnection;
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        private void CleanRepositories()
        {
            _farmRepository = null;
            _catRepository = null;
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                CleanRepositories();
                _transaction.Dispose();
            }
        }

        ~DapperUnitOfWork()
        {
            Dispose(false);
        }
    }
}