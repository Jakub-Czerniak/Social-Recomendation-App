using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using ApMobProj.Models;
using ApMobProj.Views;
using DataLibrary;
using DataLibrary.BusinessLogic;
using System.Collections.ObjectModel;

namespace ApMobProj.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class PairDetailsViewModel : BaseViewModel
    {
        private int userId;
        private string name;
        private string phoneNumber;

        public string Id { get; set; }
        public ObservableCollection<Interest> interests { get; }

        public PairDetailsViewModel()
        {
            interests = new ObservableCollection<Interest>();
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public string UserId
        {
            get { return userId.ToString(); }
            set 
            { 
                userId = Int32.Parse(value);
                LoadUserId(userId);
            }
        }

        public void LoadUserId(int userID)
        {

            var data = UserProcessor.FindUser(userID);
            Name = data[0].Name;
            PhoneNumber = data[0].PhoneNumber;

            var data1= InterestProcessor.FindInterests(userID);
            foreach (var item in data1)
            {
                interests.Add(new Interest
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
        }

    }
}
