using Android.Graphics;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.App.DownloadManager;

namespace EventPlanner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class levnt : ContentPage
	{
		public levnt ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetEvent();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeP());
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

 int current =Convert.ToInt32( (e.CurrentSelection.FirstOrDefault() as Addevent)?.EID);

            string action = await DisplayActionSheet("Delete Option ?", "Cancel", null,  "Delete");
         if (action == "Delete")
            {
                SQLiteHelper SAVER = new SQLiteHelper();
                string query1, query2;
              query2 = "delete from  Addevent where EID='" + current+"'";
                SAVER.savedata(query2);
                                collectionView.ItemsSource = await App.Database.GetEvent();
                await DisplayAlert("EVent Removed", "Deleted", "ok");
            }
            else if (action == "Edit")
            {
                await DisplayAlert("Processing", "Pendinng", "ok");

            }
        }
    }
}