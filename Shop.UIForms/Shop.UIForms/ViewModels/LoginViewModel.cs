﻿namespace Shop.UIForms.ViewModels
{

    using GalaSoft.MvvmLight.Command;
    using Shop.UIForms.Views;
    using System.Windows.Input;
    //using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter an email", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter a password", "Accept");
                return;
            }

            if (!Email.Equals("channet@ityh.com") || !Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Incorrect user or password", "Accept");
                return;
            }
            MainViewModel.GetInstance().Products = new ProductsViewModel();
            //await Application.Current.MainPage.DisplayAlert("Ok", "Fuck yeah!!!", "Accept");
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}