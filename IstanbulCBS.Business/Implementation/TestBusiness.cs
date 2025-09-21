using IstanbulCBS.Business.Interfaces;
using IstanbulCBS.Data.Repositories.Interfaces;
using IstanbulCBS.Models.Exceptions;
using IstanbulCBS.Models.Models.TestModels.Output;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Business.Implementation
{
    public class TestBusiness: ITestBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultIlceler[]> GetIlceler()
        {
            try
            {
                ResultIlceler[] result = await _unitOfWork.TestRepository.GetIlceler();
                return result;
            } catch (BusinessException ex)
            {
                throw new BusinessException(message: $"GetIlceler - {ex.Message}", logCategory: "TestBusiness");
            }
        }
    }
}
