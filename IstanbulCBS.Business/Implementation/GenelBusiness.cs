using IstanbulCBS.Business.Interfaces;
using IstanbulCBS.Data.Repositories.Interfaces;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.GenelModels.Output;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Business.Implementation
{
    public class GenelBusiness: IGenelBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenelBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultIlceById> GetIlceById(int id)
        {
            try
            {
                ResultIlceById result = await _unitOfWork.GenelRepository.GetIlceById(id);
                return result;
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GetIlceler - {ex.Message}", logCategory: "GenelBusiness");
            }
        }

        public async Task<ResultIlceler[]> GetIlceler()
        {
            try
            {
                ResultIlceler[] result = await _unitOfWork.GenelRepository.GetIlceler();
                return result;
            } catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GetIlceler - {ex.Message}", logCategory: "GenelBusiness");
            }
        }

        public async Task<ResultMahalleByMahalleId> GetMahalleByMahalleId(int mahalleId)
        {
            try
            {
                ResultMahalleByMahalleId result = await _unitOfWork.GenelRepository.GetMahalleByMahalleId(mahalleId);
                return result;
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GetMahalleByMahalleId - {ex.Message}", logCategory: "GenelBusiness");
            }
        }

        public async Task<ResultMahalleListByIlceId[]> GetMahalleListByIlceId(int ilceId)
        {
            try
            {
                ResultMahalleListByIlceId[] result = await _unitOfWork.GenelRepository.GetMahalleListByIlceId(ilceId);
                return result;

            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GetMahalleListByIlceId - {ex.Message}", logCategory: "GenelBusiness");
            }
        }
    }
}
