using cinex.Models;
using FreshMvvm;

namespace cinex.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class DetailsPageModel : FreshBasePageModel
    {
        private UpcomingModel Upcoming { get; set; }

        public string Title => Upcoming.Title;

        public string PosterPath_W200 => Upcoming.PosterPath_W200;

        public string Overview => Upcoming.Overview;

        public string Genres => Upcoming.Genres;

        public string ReleaseDate => Upcoming.ReleaseDate;

        public override void Init(object initData)
        {
            Upcoming = initData as UpcomingModel;
        }
    }
}
