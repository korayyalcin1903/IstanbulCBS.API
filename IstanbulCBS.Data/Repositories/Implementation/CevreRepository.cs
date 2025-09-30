using Dapper;
using IstanbulCBS.Data.Repositories.Interfaces;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.CevreModels.Output;
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

        public async Task<string> GetParkVeYesilAlanDetay(int id)
        {
            try
            {
                string sql = @"SELECT JSON_BUILD_OBJECT(
		                            'type', 'Feature',
		                            'geometry', ST_ASGEOJSON (ST_TRANSFORM (WKB_GEOMETRY, 4326))::JSON,
		                            'properties', JSON_BUILD_OBJECT('id', OGC_FID, 'adi', ADI)
	                            ) AS GEOJSON
                            FROM PARK_VE_YESIL_ALAN
                            WHERE OGC_FID = :id";
                var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<string>(
                    sql: sql,
                    param: new { id },
                    transaction: _unitOfWork.Transaction,
                    commandType: CommandType.Text
                );
                return result;
            }
            catch (BusinessException e)
            {
                throw new BusinessException(message: $"GetParkVeYesilAlanByIlceId - {e.Message}", logCategory: "CevreRepository");
            }
        }

        public async Task<ResultParkVeYesilAlanByIlceId[]> GetParkVeYesilAlanByIlceId(int ilceId)
        {
            try
            {
                string sql = @"SELECT ogc_fid as id, adi FROM park_ve_yesil_alan WHERE ilceId = :ilceId ORDER BY ADI";
                var result = await _unitOfWork.Connection.QueryAsync<ResultParkVeYesilAlanByIlceId>(
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
