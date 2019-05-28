using System;
using System.Collections.Generic;
using System.Text;

namespace cinex.Resources
{
    public static class AppConstants
    {
        public static readonly string LANGUAGE = "en-US";
        public static readonly string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        public static readonly string URL_GET_GENRES = $"https://api.themoviedb.org/3/genre/movie/list?language={LANGUAGE}&api_key={API_KEY}";
        public static readonly string URL_GET_UPCOMINGS = $"https://api.themoviedb.org/3/movie/upcoming?page={{0}}&language={LANGUAGE}&api_key={API_KEY}";
        public static readonly string TMBD_IMAGE_URL = "https://image.tmdb.org/t/p/w200/{0}";

        //TODO: Create internalized resources for messages
        public static readonly string ERROR = "Error";
        public static readonly string CLOSE_BUTTON_TEXT = "Close";
        public static readonly string ERROR_LOADING_UPCOMINGS = "Error loading upcomings";
        public static readonly string ERROR_LOADING_GENRES = "Error loading genres";        
    }
}
