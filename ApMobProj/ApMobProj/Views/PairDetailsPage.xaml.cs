using ApMobProj.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ApMobProj.Views
{

    public partial class PairDetailsPage : ContentPage
    {
        public PairDetailsPage()
        {
            InitializeComponent();
            BindingContext = new PairDetailsViewModel();
        }
    }
}