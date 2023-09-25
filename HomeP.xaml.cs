using Android.Content;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using Android.Content;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Android.App;

namespace EventPlanner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeP : ContentPage
	{
        public static string fullname, userid;
        public HomeP ()
		{
			InitializeComponent ();
           hom.Title= " Welcome " + fullname;
        }

     

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings);
            intent.AddFlags(ActivityFlags.NewTask);
            string package_name = "my.android.package.name";
            var uri = Android.Net.Uri.FromParts("package", package_name, null);
            intent.SetData(uri);
         
          
        }

        private async void tsklst_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new levnt());
        }

        private async void nevent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new New_event());
        }

        private void close_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }

        private async void eguest_Clicked(object sender, EventArgs e)
        {
            // var contact = await Xamarin.Essentials.Contacts.PickContactAsync();
            await Navigation.PushAsync(new Lguest());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Planning());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}