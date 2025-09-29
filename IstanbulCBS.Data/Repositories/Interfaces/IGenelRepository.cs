using IstanbulCBS.Models.Models.GenelModels.Output;

namespace IstanbulCBS.Data.Repositories.Interfaces
{
    public interface IGenelRepository
    {
        public Task<ResultIlceler[]> GetIlceler();
        public Task<string> GetIlceById(int id);
        public Task<ResultMahalleListByIlceId[]> GetMahalleListByIlceId(int ilceId);
        public Task<string> GetMahalleByMahalleId(int mahalleId);
    }
}
