using IstanbulCBS.Models.Models.TestModels.Output;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Business.Interfaces
{
    public interface ITestBusiness
    {
        public Task<ResultIlceler[]> GetIlceler();
    }
}
