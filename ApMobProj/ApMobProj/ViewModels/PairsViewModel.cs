using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ApMobProj.Models;
using ApMobProj.Views;
using DataLibrary;
using DataLibrary.BusinessLogic;
using System.Collections.ObjectModel;

namespace ApMobProj.ViewModels
{
    public class PairsViewModel : BaseViewModel
    {
        private User _selectedPair;

        public ObservableCollection<User> Pairs { get; }
        public Command LoadPairsCommand { get; }
        public Command<User> PairTapped { get; }

        public PairsViewModel()
        {
            Title = "Your matches";
            Pairs = new ObservableCollection<User>();
            LoadPairsCommand = new Command(ExecuteLoadPairsCommand);
            PairTapped = new Command<User>(OnPairSelected);
        }

        private void ExecuteLoadPairsCommand()
        {
            IsBusy = true;
            Pairs.Clear();
            var pairs =  UserProcessor.FindMatched(1);
            if (pairs.Count!=0)
                foreach (var pair in pairs)
                {
                    Pairs.Add(new User
                    {
                        Id = pair.Id,
                        Name = pair.Name
                    });
                }
            IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPair = null; 
        }

        public User SelectedPair
        {
            get => _selectedPair;
            set
            {
                SetProperty(ref _selectedPair, value);
                OnPairSelected(value);
            }
        }

        async void OnPairSelected(User user)
        {
            if (user == null)
                return;
            Routing.RegisterRoute(nameof(PairDetailsPage),typeof(PairDetailsPage));
            await Shell.Current.GoToAsync($"{nameof(PairDetailsPage)}?{nameof(PairDetailsViewModel.UserId)}={user.Id}");
        }


    }
}
