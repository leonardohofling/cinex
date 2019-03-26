using cinex.Models;
using RestSharp;
using System.Threading.Tasks;

namespace cinex.Services
{
    public class AppService : IAppService
    {
        private static string LANGUAGE = "en-US";
        private static string API_KEY = "1f54bd990f1cdfb230adb312546d765d";

        public AppService()
        {

        }

        public async Task<GenresResponseModel> GetGenresAsync()
        {
            var client = new RestClient($"https://api.themoviedb.org/3/genre/movie/list?language={LANGUAGE}&api_key={API_KEY}");

            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteTaskAsync<GenresResponseModel>(request);

            return response.Data;
        }

        public async Task<UpcomingResponseModel> GetUpcomingAsync(int page)
        {
            var client = new RestClient($"https://api.themoviedb.org/3/movie/upcoming?page={page}&language={LANGUAGE}&api_key={API_KEY}");

            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteTaskAsync<UpcomingResponseModel>(request);

            return response.Data;
        }
    }
}
