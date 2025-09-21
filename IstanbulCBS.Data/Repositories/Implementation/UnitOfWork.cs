using IstanbulCBS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Data.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private bool _disposed;


        private static readonly AsyncLocal<IDbTransaction> _transaction = new AsyncLocal<IDbTransaction>();


        public IDbConnection Connection => _connection;

        public IDbTransaction Transaction => _transaction.Value;


        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }


        #region Repositories
        private readonly ITestRepository? _testRepository;

        public ITestRepository TestRepository => _testRepository ?? new TestRepository(this);

        #endregion Repositories


        public void BeginTransaction()
        {
            if (_transaction.Value == null)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                _transaction.Value = _connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            _transaction.Value?.Commit();
            _transaction.Value?.Dispose();
            _transaction.Value = null;  // **Transaction tamamlandıktan sonra temizleniyor**
        }

        public void Rollback()
        {
            _transaction.Value?.Rollback();
            _transaction.Value?.Dispose();
            _transaction.Value = null;  // **Rollback sonrası temizleniyor**
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _transaction.Value?.Dispose();
                _transaction.Value = null;
                _connection?.Dispose();
                _disposed = true;
            }
        }
    }
}
