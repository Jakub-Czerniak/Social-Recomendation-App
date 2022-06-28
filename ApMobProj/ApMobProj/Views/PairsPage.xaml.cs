using ApMobProj.Models;
using ApMobProj.ViewModels;
using ApMobProj.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApMobProj.Views
{
    public partial class PairsPage : ContentPage
    {
        PairsViewModel _viewModel;
        public PairsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PairsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }

}