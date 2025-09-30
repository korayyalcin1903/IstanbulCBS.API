using IstanbulCBS.Business.Interfaces;
using IstanbulCBS.Models;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.CevreModels.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IstanbulCBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CevreController : ControllerBase
    {
        private readonly ICevreBusiness _business;

        public CevreController(ICevreBusiness business)
        {
            _business = business;
        }

        [HttpGet("park_yesil_alan/{ilceId}")]
        public async Task<ApiResponse<ResultParkVeYesilAlanByIlceId[]>> GetMahalleByMahalleId(int ilceId)
        {
            try
            {
                var result = await _business.GetParkVeYesilAlanByIlceId(ilceId);
                if (result == null || result.Length <= 0)
                {
                    return ApiResponse<ResultParkVeYesilAlanByIlceId[]>.Fail("Park veya yeşil alan bulunamadı");
                }
                return ApiResponse<ResultParkVeYesilAlanByIlceId[]>.Ok(result, "Park veya yeşil alan listelenmiştir");
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"CevreController - {ex.Message}", logCategory: "Controller");
            }
        }

        [HttpGet("park_yesil_alan_detay/{id}")]
        public async Task<ApiResponse<string>> GetParkVeYesilAlanDetay(int id)
        {
            try
            {
                var result = await _business.GetParkVeYesilAlanDetay(id);
                if (string.IsNullOrEmpty(result))
                {
                    return ApiResponse<string>.Fail("Park veya yeşil alan bulunamadı");
                }
                return ApiResponse<string>.Ok(result, "Park veya yeşil alan detay bilgisi getirilmiştir");
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"CevreController - {ex.Message}", logCategory: "Controller");
            }
        }
    }
}
