using Dapper;
using IstanbulCBS.Data.Repositories.Interfaces;
using IstanbulCBS.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Data.Repositories.Implementation
{
    public class CevreRepository: ICevreRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CevreRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string[]> GetParkVeYesilAlanByIlceId(int ilceId)
        {
            try
            {
                string sql = @"
                        SELECT
	                        JSON_BUILD_OBJECT(
		                        'type', 'Feature',
		                        'geometry', ST_ASGEOJSON (wkt_geom)::JSON,
		                        'properties', JSON_BUILD_OBJECT(
			                                                'id', OGC_FID,
			                                                'adi', adi
		                                                )
	                                                ) AS GEOJSON
                            FROM park_ve_yesil_alan
                            WHERE ilceId = :ilceId
                        ";
                var result = await _unitOfWork.Connection.QueryAsync<string>(
                    sql: sql,
                    param: new { ilceId },
                    transaction: _unitOfWork.Transaction,
                    commandType: CommandType.Text
                );
                return result.ToArray();
            }
            catch (BusinessException e)
            {
                throw new BusinessException(message: $"GetParkVeYesilAlanByIlceId - {e.Message}", logCategory: "CevreRepository");
            }
        }
    }
}
