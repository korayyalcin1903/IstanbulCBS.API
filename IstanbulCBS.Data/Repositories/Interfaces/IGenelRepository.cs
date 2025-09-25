using IstanbulCBS.Models.Models.GenelModels.Output;

namespace IstanbulCBS.Data.Repositories.Interfaces
{
    public interface IGenelRepository
    {
        public Task<ResultIlceler[]> GetIlceler();
        public Task<ResultIlceById> GetIlceById(int id);
        public Task<ResultMahalleListByIlceId[]> GetMahalleListByIlceId(int ilceId);
        public Task<ResultMahalleByMahalleId> GetMahalleByMahalleId(int mahalleId);
    }
}
