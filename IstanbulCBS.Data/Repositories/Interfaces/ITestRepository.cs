using IstanbulCBS.Models.Models.TestModels.Output;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Data.Repositories.Interfaces
{
    public interface ITestRepository
    {
        public Task<ResultIlceler[]> GetIlceler();
    }
}
