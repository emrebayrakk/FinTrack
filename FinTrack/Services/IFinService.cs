using FinTrack.Data.Entities;
using FinTrack.Dtos;

namespace FinTrack.Services
{
    public interface IFinService
    {
        Task<ResponseData<AllHisseResponse>> AllReadHisse();
        Task<ResponseData<DetayliResponse>> DetayliHisse(string hisseAdi);
        IQueryable<BorsaHisse> GetHisseler();
    }
}
