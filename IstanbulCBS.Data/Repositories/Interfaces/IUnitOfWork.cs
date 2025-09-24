using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        #region Repositories
        IGenelRepository GenelRepository { get; }
        #endregion Repositories

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
