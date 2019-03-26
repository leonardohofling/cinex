using cinex.Models;
using cinex.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace cinex.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class MainPageModel : FreshBasePageModel
    {
        IAppService _appService;

        private int NextPage { get; set; } = 1;

        private int TotalPages { get; set; } = 1;

        public bool IsLoading { get; set; }

        public string Title { get; set; }

        public ObservableCollection<UpcomingModel> Upcomings { get; }

        public List<UpcomingModel> OriginalUpcomings { get; set; }

        public List<GenreModel> Genres { get; }

        public bool ShowLoadMore { get; set; }

        private string _searchString;
        public string SearchString
        {
            get => _searchString;
            set
            {
                if (!EqualityComparer<string>.Default.Equals(_searchString, value))
                {
                    _searchString = value;
                    FilterUpcomings();
                }

                ShowLoadMore = string.IsNullOrEmpty(_searchString);
            }
        }

        private UpcomingModel _selectedItem;
        public UpcomingModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                {
                    ShowUpcomingDetailsCommand.Execute(_selectedItem);
                }
            }
        }

        public MainPageModel(IAppService appService)
        {
            Title = "CineX - Upcomings";
            OriginalUpcomings = new List<UpcomingModel>();
            Upcomings = new ObservableCollection<UpcomingModel>();
            Genres = new List<GenreModel>();
            _appService = appService;
        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            if (Upcomings.Count == 0)
            {
                this.IsLoading = true;

                await LoadGenres();
                await LoadUpcomings();

                this.IsLoading = false;
            }

            SelectedItem = null;
        }

        public Command LoadMoreCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsLoading = true;

                    await LoadUpcomings();

                    IsLoading = false;
                });
            }
        }
        public Command ShowUpcomingDetailsCommand
        {
            get
            {
                return new Command(async (upcomingModel) =>
                {
                    await CoreMethods.PushPageModel<DetailsPageModel>(upcomingModel, false);
                });
            }
        }

        public Command FilterUpcomingsCommand
        {
            get
            {
                return new Command(() =>
                {
                    FilterUpcomings();
                });
            }
        }

        public Command ListViewRefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsLoading = true;

                    await LoadUpcomings(true);

                    IsLoading = false;
                });
            }
        }

        private async Task LoadGenres()
        {
            try
            {
                var genresResponseModel = await _appService.GetGenresAsync();
                foreach (var genre in genresResponseModel.Genres)
                {
                    this.Genres.Add(genre);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task LoadUpcomings(bool clearOriginalUpcomings = false)
        {
            try
            {
                if (clearOriginalUpcomings)
                {
                    NextPage = 1;
                    OriginalUpcomings.Clear();
                    Upcomings.Clear();
                }

                var upcomingResponseModel = await _appService.GetUpcomingAsync(NextPage);

                upcomingResponseModel.Results.ForEach(upcoming =>
                {
                    upcoming.GenresNames = upcoming.GenreIds.Select(id => Genres.FirstOrDefault(genre => genre.Id.Equals(id))?.Name).ToList();
                    OriginalUpcomings.Add(upcoming);
                });

                FilterUpcomings();

                TotalPages = upcomingResponseModel.TotalPages;
                NextPage++;

                ShowLoadMore = NextPage <= TotalPages;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void FilterUpcomings()
        {
            Upcomings.Clear();

            List<UpcomingModel> upcomingModelsFiltered = new List<UpcomingModel>();

            if (!String.IsNullOrEmpty(SearchString))
            {
                var searchString = SearchString.ToLowerInvariant();
                upcomingModelsFiltered.AddRange(OriginalUpcomings.Where(upcoming => upcoming.Title.ToLowerInvariant().Contains(searchString)));
            }
            else
            {
                upcomingModelsFiltered.AddRange(OriginalUpcomings);
            }

            upcomingModelsFiltered.ForEach(upcoming => Upcomings.Add(upcoming));
        }
    }
}
