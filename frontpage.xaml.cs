using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
namespace EventPlanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frontpage : ContentPage
    {
       
        public frontpage()
        {
            InitializeComponent();
           
        }

     public  async void Cont_Clicked(object sender, EventArgs e)
        {
          
            await Navigation.PushAsync(new LoginPage()); 
        }

        private async void reg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new signin());
           

        }



    }
}