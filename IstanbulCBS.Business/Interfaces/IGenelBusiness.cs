using IstanbulCBS.Models.Models.GenelModels.Output;

namespace IstanbulCBS.Business.Interfaces
{
    public interface IGenelBusiness
    {
        public Task<ResultIlceler[]> GetIlceler();
        public Task<ResultIlceById> GetIlceById(int id);
    }
}
