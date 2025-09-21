using Dapper;
using IstanbulCBS.Data.Repositories.Interfaces;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.TestModels.Output;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Data.Repositories.Implementation
{
    public class TestRepository: ITestRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultIlceler[]> GetIlceler()
        {
            try
            {
                var sql = "SELECT ST_AsText(wkb_geometry) AS geometry, display_name as ilceAdi FROM istanbul_ilceler";
                var result = await _unitOfWork.Connection.QueryAsync<ResultIlceler>(
                    sql,
                    transaction: _unitOfWork.Transaction
                );

                return result.ToArray();
            }
            catch (BusinessException e)
            {
                throw new BusinessException(message: $"GetIlceler - {e.Message}", logCategory: "TestRepository");
            }

        }
    }
}
