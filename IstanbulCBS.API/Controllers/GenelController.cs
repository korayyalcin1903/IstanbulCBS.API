using IstanbulCBS.Business.Interfaces;
using IstanbulCBS.Models;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.GenelModels.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IstanbulCBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenelController : ControllerBase
    {
        private readonly IGenelBusiness _business;

        public GenelController(IGenelBusiness business)
        {
            _business = business;
        }

        [HttpGet("ilceler")]
        public async Task<ApiResponse<ResultIlceler[]>> GetIlceler()
        {
            try
            {
                var result = await _business.GetIlceler();
                if (result == null)
                {
                    return ApiResponse<ResultIlceler[]>.Fail("İlçeler bulunamadı");
                }
                return ApiResponse<ResultIlceler[]>.Ok(result, "İlçeler listelenmiştir");
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GenelController - {ex.Message}", logCategory: "Controller");
            }
        }


        [HttpGet("ilce/{id}")]
        public async Task<ApiResponse<ResultIlceById>> GetIlceById(int id)
        {
            try
            {
                var result = await _business.GetIlceById(id);
                if (result == null)
                {
                    return ApiResponse<ResultIlceById>.Fail("İlçe bulunamadı");
                }
                return ApiResponse<ResultIlceById>.Ok(result, "İlçe listelenmiştir");
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GenelController - {ex.Message}", logCategory: "Controller");
            }
        }
    }
}
