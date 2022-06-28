using ApMobProj.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ApMobProj.Views
{
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel _viewModel;
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ProfileViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}