using cinex.Models;
using cinex.Resources;
using RestSharp;
using System.Threading.Tasks;

namespace cinex.Services
{
    public class AppService : IAppService
    {
        public AppService()
        {

        }

        public async Task<GenresResponseModel> GetGenresAsync()
        {
            var client = new RestClient(AppConstants.URL_GET_GENRES);

            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteTaskAsync<GenresResponseModel>(request);

            if (response != null && response.IsSuccessful)
                return response.Data;

            throw new System.Exception(AppConstants.ERROR_LOADING_GENRES);
        }

        public async Task<UpcomingResponseModel> GetUpcomingAsync(int page)
        {
            var client = new RestClient(string.Format(AppConstants.URL_GET_UPCOMINGS, page));

            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteTaskAsync<UpcomingResponseModel>(request);

            if (response != null && response.IsSuccessful)
                return response.Data;

            throw new System.Exception(AppConstants.ERROR_LOADING_UPCOMINGS);
        }
    }
}
