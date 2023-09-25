using EventPlanner.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventPlanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class signin : ContentPage
    {
        public signin()
        {
            InitializeComponent();
        }

        private async void savedata()
        {
            if (!string.IsNullOrWhiteSpace(email.Text) && !string.IsNullOrWhiteSpace(contact.Text)
             && !string.IsNullOrWhiteSpace(nation.Text)
                  && !string.IsNullOrWhiteSpace(password.Text))
            {
                if (password.Text.Length <= 5)
                {
                    await DisplayAlert("Password Must not lesser than 6char", "Invalid Data Supplied", "ok");
                    return;
                }


                await App.Database.SavePersonAsync(new Person
                {
                    Name = Name.Text,
                    contact = contact.Text,
                    email = email.Text,
                   
                    nation = nation.Text,
                    password = password.Text,
                });
                await DisplayAlert("Regsitration Successful", "Successful", "ok");
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("All filed require", "Invalid Data Supplied", "ok");

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new frontpage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void regbtn_Clicked_2(object sender, EventArgs e)
        {
            savedata();
        }
    }
}