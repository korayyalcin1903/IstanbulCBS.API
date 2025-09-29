using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Business.Interfaces
{
    public interface ICevreBusiness
    {
        public Task<string[]> GetParkVeYesilAlanByIlceId(int ilceId);
    }
}
