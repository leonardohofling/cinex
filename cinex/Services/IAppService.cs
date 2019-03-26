using cinex.Models;
using System.Threading.Tasks;

namespace cinex.Services
{
    public interface IAppService
    {
        Task<GenresResponseModel> GetGenresAsync();
        Task<UpcomingResponseModel> GetUpcomingAsync(int page);
    }
}
