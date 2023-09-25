using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
namespace EventPlanner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lmaps : ContentPage

	{
        private readonly Geocoder _geocoder = new Geocoder();

        public Lmaps ()
		{
			InitializeComponent ();
            Map map = new Map();
            Content = map;

        }
        double cars;

        private async void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
            var adresses = await _geocoder.GetAddressesForPositionAsync(e.Position);
           // finished.loclat = e.Position.Latitude;s
            //finished.loclog = e.Position.Longitude;
           New_event.loc = adresses.FirstOrDefault()?.ToString();
            await DisplayAlert("Location", adresses.FirstOrDefault()?.ToString(), "ok");
            await Navigation.PushAsync(new New_event());

        }
    }
}