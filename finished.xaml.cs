using Android.Graphics;
using Android.Icu.Text;
using Android.Views.Animations;
using EventPlanner.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.App.DownloadManager;

namespace EventPlanner.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class finished : ContentPage
	{

        public static string locname,  Etype, Edate, Oname;
		public static double loclat, loclog,eid;

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            SQLiteHelper SAVER = new SQLiteHelper();
            string query1, query2;
            query2 = "update  Addevent SET food='" + food.Text +"', hall='" + hall.Text+"', mc='" + mc.Text
                +"', artist='" + artist.Text+"', tras ='"+ tras.Text+ "', deco='" 
                + deco.Text+"', total='"+ tot.Text+"', ch='" +ch.Text+ "' where EID='" + eid + "'";
            SAVER.savedata(query2);
            await DisplayAlert("Successful", "Planned", "Ok");
        }
        double foods, hal, trans, mcs, act, dres, chai;
        private void BorderlessEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            double total = Convert.ToDouble(tot.Text);
            
            foods=(40*total)/100;
          hal=(16.5 * total)/100;
          mcs=(4 * total)/ 100;
          act=(6 * total)/ 100;
           dres = ( 20* total) / 100;
         chai = ( 10* total) / 100;

            food.Text = "Food Budget  #"+ foods.ToString();
            hall.Text="Hall Budget #"+hal.ToString();
            mc.Text ="MC  #" + mcs.ToString();
            artist.Text="Artist  #"+ act.ToString();
            ch.Text = "Extra Hall Chair "+  chai.ToString();
deco.Text="Decoration " + dres.ToString();
            trans= (4.5 * total) / 100;
            tras.Text ="Transportation " + trans.ToString();
                   }

        public finished ()
		{
			InitializeComponent ();
			


          


            }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            finishs.Title = Etype;
            ename.Text = Etype.ToString();
            owner.Text = Oname;
            edate.Text = Edate;
         

        }

        private async void Button_Clicked(object sender, EventArgs e)
			        {
       await Navigation.PushModalAsync( new Lmaps());
		//	loc.Text = locname;
          //  Navigation.RemovePage(this);
        }
    }
}