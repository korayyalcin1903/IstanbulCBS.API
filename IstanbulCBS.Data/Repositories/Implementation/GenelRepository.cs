using Dapper;
using IstanbulCBS.Data.Repositories.Interfaces;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.GenelModels.Output;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
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
                var sql = @"
                            SELECT 
                                ogc_fid AS id,
                                TRIM(SPLIT_PART(display_name, ',', 1)) AS ilceadi,
                                ST_AsText(wkb_geometry) AS geometry
                            FROM public.istanbul_ilceler
                            WHERE ogc_fid = @id;
                        ";

                var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ResultIlceById>(
                    sql,
                    param: new { id },
                    transaction: _unitOfWork.Transaction
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
                var sql = "SELECT ogc_fid as id, trim(split_part(display_name, ',', 1)) as ilceAdi FROM istanbul_ilceler order by ilceAdi";
                var result = await _unitOfWork.Connection.QueryAsync<ResultIlceler>(
                    sql,
                    transaction: _unitOfWork.Transaction
                );

                return result.ToArray();
            }
            catch (BusinessException e)
            {
                throw new BusinessException(message: $"GetIlceler - {e.Message}", logCategory: "GenelRepository");
            }

        }
    }
}
