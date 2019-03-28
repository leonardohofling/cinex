using cinex.PageModels;
using Xamarin.Forms;

namespace cinex.Pages
{
    public partial class MainPage : ContentPage
    {
        private MainPageModel ViewModel => this.BindingContext as MainPageModel;

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
