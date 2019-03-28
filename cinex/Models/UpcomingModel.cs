using cinex.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace cinex.Models
{
    public class UpcomingModel
    {
        [JsonProperty(PropertyName = "vote_count")]
        public int VoteCount { get; set; }

        public int Id { get; set; }

        public bool Video { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public double VoteAverage { get; set; }

        public string Title { get; set; }

        public double Popularity { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        public string PosterPath_W200 =>  string.Format(AppConstants.TMBD_IMAGE_URL, PosterPath);

        [JsonProperty(PropertyName = "original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty(PropertyName = "original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty(PropertyName = "genre_ids")]
        public List<int> GenreIds { get; set; }

        public List<string> GenresNames { get; set; }

        public string Genres => String.Join(", ", GenresNames);

        [JsonProperty(PropertyName = "backdrop_path")]
        public string BackdropPath { get; set; }

        public bool Adult { get; set; }

        public string Overview { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        public UpcomingModel()
        {
        }
    }
}
