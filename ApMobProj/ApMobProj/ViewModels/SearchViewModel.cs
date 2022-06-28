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
    public class SearchViewModel : BaseViewModel
    {
        private Pair _decision;
        private User _user;
        private string name;
        public ObservableCollection<Interest> Interests { get; }
        public Command YTapped { get; }
        public Command NTapped { get; }
        public Command LoadUser { get; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public SearchViewModel()
        {
            Interests = new ObservableCollection<Interest>();
            _decision = new Pair();
            _user = new User();
            YTapped = new Command(OnYClicked);
            NTapped = new Command(OnNClicked);
            LoadUser = new Command(ExecuteLoadUser);
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
        private void ExecuteLoadUser()
        {
            IsBusy = true;
            Interests.Clear();
            Name = null;
            var user = UserProcessor.FindBestMatch(1);
            if (user.Count != 0)
            {
                _decision.User1Id = 1;
                _decision.User2Id = user[0].Id;
                _user.Id = user[0].Id;
                _user.Name = user[0].Name;
                Name = user[0].Name;

                var interestsData = InterestProcessor.FindInterests(_user.Id);

                foreach (var interest in interestsData)
                {
                    Interests.Add(new Interest
                    {
                        Name = interest.Name
                    });
                }
            }
            IsBusy = false;
        }
        private void OnYClicked(object obj)
        {
            _decision.User1Decision = "y";
            PairProcessor.SendDecision(_decision.User1Id, _decision.User2Id, _decision.User1Decision);
            ExecuteLoadUser();
        }

        private void OnNClicked(object obj)
        {
            _decision.User1Decision = "n";
            PairProcessor.SendDecision(_decision.User1Id, _decision.User2Id, _decision.User1Decision);
            ExecuteLoadUser();
        }



    }
}
