using IstanbulCBS.Business.Interfaces;
using IstanbulCBS.Models;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.TestModels.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using System.Threading.Tasks;

namespace IstanbulCBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestBusiness _testBusiness;

        public TestController(ITestBusiness testBusiness)
        {
            _testBusiness = testBusiness;
        }

        [HttpGet]
        public async Task<ApiResponse<ResultIlceler[]>> GetIlceler()
        {
            try
            {
                var result = await _testBusiness.GetIlceler();
                if (result == null)
                {
                    return ApiResponse<ResultIlceler[]>.Fail("İlçeler bulunamdı");
                }
                return ApiResponse<ResultIlceler[]>.Ok(result, "İlçeler listelenmiştir");
            } catch (BusinessException ex)
            {
                throw new BusinessException(message: $"TestController - {ex.Message}", logCategory: "Controller");
            }
        }
    }
}
