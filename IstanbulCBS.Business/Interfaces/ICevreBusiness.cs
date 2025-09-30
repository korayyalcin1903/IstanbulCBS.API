using IstanbulCBS.Models.Models.CevreModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Business.Interfaces
{
    public interface ICevreBusiness
    {
        public Task<ResultParkVeYesilAlanByIlceId[]> GetParkVeYesilAlanByIlceId(int ilceId);
        public Task<string> GetParkVeYesilAlanDetay(int id);
    }
}
