using EventPlanner.Models;
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
	public partial class Planning : ContentPage
	{
		public Planning ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetEvent();

        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int current = Convert.ToInt32((e.CurrentSelection.FirstOrDefault() as Addevent)?.EID);
            finished.Edate = (e.CurrentSelection.FirstOrDefault() as Addevent)?.edate.ToString();
            finished.Etype = (e.CurrentSelection.FirstOrDefault() as Addevent)?.etype.ToString();
            finished.Oname = (e.CurrentSelection.FirstOrDefault() as Addevent)?.Name.ToString();
            finished.eid = current;
           // await DisplayAlert(finished.Edate, finished.Oname, finished.Etype);
            await Navigation.PushAsync(new finished());
                    }
    }
}