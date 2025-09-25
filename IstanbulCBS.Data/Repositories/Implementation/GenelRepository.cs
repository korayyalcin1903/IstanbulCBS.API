using Dapper;
using IstanbulCBS.Data.Repositories.Interfaces;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.GenelModels.Output;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Data.Repositories.Implementation
{
    public class GenelRepository : IGenelRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenelRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultIlceById> GetIlceById(int id)
        {
            try
            {
                string sql = @"
                            SELECT 
                                ogc_fid AS id,
                                TRIM(SPLIT_PART(display_name, ',', 1)) AS ilceadi,
                                ST_AsText(wkb_geometry) AS geometry
                            FROM public.istanbul_ilceler
                            WHERE ogc_fid = @id;
                        ";

                var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ResultIlceById>(
                    sql:sql,
                    param: new { id },
                    transaction: _unitOfWork.Transaction,
                    commandType: CommandType.Text
                );

                return result;
            }
            catch (BusinessException e)
            {
                throw new BusinessException(message: $"GetIlceById - {e.Message}", logCategory: "GenelRepository");
            }
        }

        public async Task<ResultIlceler[]> GetIlceler()
        {
            try
            {
                string sql = "SELECT ogc_fid as id, trim(split_part(display_name, ',', 1)) as ilceAdi FROM istanbul_ilceler order by ilceAdi";
                var result = await _unitOfWork.Connection.QueryAsync<ResultIlceler>(
                    sql:sql,
                    transaction: _unitOfWork.Transaction,
                    commandType: CommandType.Text
                );

                return result.ToArray();
            }
            catch (BusinessException e)
            {
                throw new BusinessException(message: $"GetIlceler - {e.Message}", logCategory: "GenelRepository");
            }

        }

        public async Task<ResultMahalleByMahalleId> GetMahalleByMahalleId(int mahalleId)
        {
            try
            {
                string sql = @"SELECT OGC_FID AS ID, TRIM(SPLIT_PART(DISPLAY_NAME, ',', 1)) AS MAHALLEADI, ST_ASTEXT (WKB_GEOMETRY) AS GEOMETRY
                        FROM ISTANBUL_MAHALLELER
                        WHERE OGC_FID = :mahalleId";
                var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ResultMahalleByMahalleId>(
                    sql: sql,
                    param: new { mahalleId },
                    transaction: _unitOfWork.Transaction,
                    commandType: CommandType.Text
                );
                return result;
            }
            catch (BusinessException e)
            {
                throw new BusinessException(message: $"GetMahalleByMahalleId - {e.Message}", logCategory: "GenelRepository");
            }
        }

        public async Task<ResultMahalleListByIlceId[]> GetMahalleListByIlceId(int ilceId)
        {
            try
            {
                string sql = @"SELECT OGC_FID AS id, TRIM(SPLIT_PART(DISPLAY_NAME, ',', 1)) AS mahalleAdi 
                                FROM ISTANBUL_MAHALLELER 
                                WHERE ILCE_ID = :ilceId order by mahalleAdi";

                var result = await _unitOfWork.Connection.QueryAsync<ResultMahalleListByIlceId>(
                    sql: sql,
                    param: new { ilceId },
                    transaction: _unitOfWork.Transaction,
                    commandType: CommandType.Text
                );

                return result.ToArray();
            }
            catch (BusinessException e)
            {
                throw new BusinessException(message: $"GetMahalleListByIlceId - {e.Message}", logCategory: "GenelRepository");
            }
        }
    }
}
