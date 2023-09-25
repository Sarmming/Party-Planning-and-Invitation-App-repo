using EventPlanner.Models;
using EventPlanner.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace EventPlanner.Views
{
    
        [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
         
            }

        private async void btnlogin_Clicked(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(password.Text) || String.IsNullOrEmpty(email.Text))
            {
                await DisplayAlert("Empty Field", "Invalid Data Supplied", "ok");
                return;
            }
            dbsql.create_user_table();
            var db = new SQLiteConnection(dbsql.dbpath);
            var data = db.Table<Person>(); //Call Table  
            var data1 = data.Where(x => x.email == email.Text && x.password == password.Text).FirstOrDefault(); //Linq Query  
            if (data1 != null)
            {
               HomeP.userid = data1.PersonID.ToString();
            HomeP.fullname = data1.Name;
                await DisplayAlert("Login", "Succeded", "ok");
                 await Navigation.PushAsync(new HomeP());
                //await Shell.Current.GoToAsync("//AdminPage");

            }
            else
            {
                await DisplayAlert("Invalid Username | Password", "Invalid Data Supplied", "Cancel");
            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new signin());

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}