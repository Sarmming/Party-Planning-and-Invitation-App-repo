
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventPlanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }
        async void recent()
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(conEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    contact = (conEntry.Text),
                    email = emailEntry.Text,
                });

                nameEntry.Text = conEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
            else
            {
                await DisplayAlert("Invalid Data Supplied", "Error", "Cancel");

            }

        }

        private async void idm_Clicked(object sender, EventArgs e)
        {


        }

        private async void Button_Clicked(object sender, EventArgs e)


        {
            SQLiteHelper SAVER = new SQLiteHelper();
            string query1, query2;
           // query1 = "Select count(*) from Person where email='" + emailEntry.Text.ToLower() + "' or  contact='" + conEntry.Text + "'";


            query2 = "insert into Person (Name,email, contact) values ('" + nameEntry.Text + "','" + emailEntry.Text + "','" + conEntry.Text + "')";
            SAVER.savedata(query2);



            //  SAVER.get_data(query1);
            /*                        await DisplayAlert(SAVER.Response, "Response", "Ok");
             /if (SAVER.Response=="nill")
             {

                 await DisplayAlert(SAVER.Response, "Response", "Ok");
                             }
             else
             {
                 await DisplayAlert("Already exist", "Response", "Ok");
                             }
             collectionView.ItemsSource = await App.Database.GetPeopleAsync();
             */
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string previous = (e.PreviousSelection.FirstOrDefault() as Person)?.Name;
            string current = (e.CurrentSelection.FirstOrDefault() as Person)?.Name;
            await DisplayAlert(current, "Selected", "ok");


        }
    }
}