using IstanbulCBS.Models.Models.GenelModels.Output;

namespace IstanbulCBS.Business.Interfaces
{
    public interface IGenelBusiness
    {
        public Task<ResultIlceler[]> GetIlceler();
        public Task<string> GetIlceById(int id);
        public Task<ResultMahalleListByIlceId[]> GetMahalleListByIlceId(int ilceId);
        public Task<string> GetMahalleByMahalleId(int mahalleId);
        public Task<string[]> GetIlcelerGeom();
    }
}
