using IstanbulCBS.Business.Interfaces;
using IstanbulCBS.Data.Repositories.Implementation;
using IstanbulCBS.Data.Repositories.Interfaces;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.CevreModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Business.Implementation
{
    public class CevreBusiness : ICevreBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public CevreBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GetParkVeYesilAlanDetay(int id)
        {
            try
            {
                string result = await _unitOfWork.CevreRepository.GetParkVeYesilAlanDetay(id);
                return result;
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GetParkVeYesilAlanDetay - {ex.Message}", logCategory: "CevreBusiness");
            }
        }

        public async Task<ResultParkVeYesilAlanByIlceId[]> GetParkVeYesilAlanByIlceId(int ilceId)
        {
            try
            {
                ResultParkVeYesilAlanByIlceId[] result = await _unitOfWork.CevreRepository.GetParkVeYesilAlanByIlceId(ilceId);
                return result;
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GetParkVeYesilAlanByIlceId - {ex.Message}", logCategory: "CevreBusiness");
            }
        }
    }
}
