
using Android.App;
using Android.Util;
using EventPlanner.Models;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
namespace EventPlanner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class New_event : ContentPage
	{
		public New_event ()
		{
			InitializeComponent ();
            evenue.Text = loc;
        }
        public New_event MyProperty { get; set; }
       public static string conta,loc;
        async void recent()
        {
            if (!string.IsNullOrWhiteSpace(Name.Text)
                              && !string.IsNullOrWhiteSpace(evenue.Text)  && etype.SelectedIndex !=-1
                )
            {
                int selectedIndex =etype.SelectedIndex;
                await App.Database.SaveEvent(new Addevent
                {
                   Name= Name.Text,
                                     evenue = evenue.Text,
                   etype= (string)etype.ItemsSource[selectedIndex],
                    etime = etime.Time.ToString(),
                    edate = edate.Date.ToString(),
                    gcon=conta,
                                       eguest=eguest.Text,

                });
                try
                { var smsMessenger = CrossMessaging.Current.SmsMessenger;
                    string msg = "Event Notification [ Location "+ evenue.Text +"  from \n";
                    msg=msg+ Name.Text+ " Time "+ etime.Time.ToString();
                    msg = msg + "Date " + edate.Date.ToString()+"]";

                    smsMessenger.SendSms(conta, msg);
                }
                catch 
                { Exception ex; }

                Name.Text =  string.Empty;
                await DisplayAlert("Event Added !!!!!", "Sucess", "Ok");
               
            }
            else
            {
                await DisplayAlert("Invalid Data Supplied", "Error", "Ok");

            }

        }

        private void submit_Clicked(object sender, EventArgs e)
        {
            recent();
        }

        private  async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var contact = await Xamarin.Essentials.Contacts.PickContactAsync();

                if (contact == null)
                {
                    return;
                }


                else
                {
                    var phones = contact.Phones.ToList(); // List of phone numbers  
                  
                         conta = phones[0].ToString();
                  
                   

                }
            }
           
            catch (Exception ex)
            {
                // Handle exception here.  
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeP());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Lmaps());
        evenue.Text = loc;
        }
    }
}