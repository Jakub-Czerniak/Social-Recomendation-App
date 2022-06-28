using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ApMobProj.Models;
using ApMobProj.ViewModels;
using ApMobProj.Views;

namespace ApMobProj.Views
{
    
    public partial class SearchPage : ContentPage
    {
        SearchViewModel _viewModel;
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new SearchViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}