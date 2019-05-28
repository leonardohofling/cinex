using cinex.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace cinex.Models
{
    public class UpcomingModel
    {
        public int VoteCount { get; set; }

        public int Id { get; set; }

        public bool Video { get; set; }

        public double VoteAverage { get; set; }

        public string Title { get; set; }

        public double Popularity { get; set; }

        public string PosterPath { get; set; }

        public string PosterPath_W200 =>  string.Format(AppConstants.TMBD_IMAGE_URL, PosterPath);

        public string OriginalLanguage { get; set; }

        public string OriginalTitle { get; set; }

        public List<int> GenreIds { get; set; }

        public List<string> GenresNames { get; set; }

        public string Genres => String.Join(", ", GenresNames);

        public string BackdropPath { get; set; }

        public bool Adult { get; set; }

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }

        public UpcomingModel()
        {
        }
    }
}
