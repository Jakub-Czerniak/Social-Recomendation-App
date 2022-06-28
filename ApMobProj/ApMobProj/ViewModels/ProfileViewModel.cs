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
    public class ProfileViewModel : BaseViewModel
    {
        private int userId;
        private string name;
        private string phoneNumber;

        public string Id { get; set; }
        public ObservableCollection<Interest> interests { get; }

        public ProfileViewModel()
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

        public void OnAppearing()
        {
            LoadUserId();
        }

        public void LoadUserId()
        {
            interests.Clear();
            var data = UserProcessor.FindUser(1);
            Name = data[0].Name;
            PhoneNumber = data[0].PhoneNumber;

            var data1 = InterestProcessor.FindInterests(1);
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
