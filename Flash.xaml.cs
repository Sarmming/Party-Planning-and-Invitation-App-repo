using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventPlanner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Flash : ContentPage
    {
        Timer timer;
        int a = 0;
        public Flash()
        {
            InitializeComponent();

           
        }
        protected override void OnDisappearing()
        {
            timer?.Dispose();
            base.OnDisappearing();
        }



        protected void timer_Elaspsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread((Action)(() =>
            {
                coded();

            }));
               
        }

        private async  void coded()
        {
            a = a + 1;
           
            if (a == 3)
            {
                //   timer.Dispose();

                await img.ScaleTo(360, 2000, Easing.CubicIn);

                await img1.RotateTo(360, 2000, Easing.SinInOut);
            //    await img.TranslateTo(0, 200, 2000, Easing.BounceIn);
            }
          else  if (a == 5)
            {
                await Navigation.PushAsync(new frontpage());
                //await img.TranslateTo(0, 200, 2000, Easing.BounceIn);
                //   
                //  await img.RotateTo(360, 2000, Easing.SinInOut);
                //  await img.TranslateTo(0, -200, 2000, Easing.BounceOut);
                // await img.ScaleTo(1, 2000, Easing.CubicOut);
                // await img.TranslateTo(0, 200, 2000, Easing.BounceIn);
                timer.Enabled = false;
            }
            if (a == 9)
            {
                await img.TranslateTo(0, 200, 2000, Easing.BounceIn);
                // await Navigation.PushAsync(new frontpage());
                //timer.Stop();
                //timer.Dispose();
            }
            else if (a == 12) {
                await img.TranslateTo(0, 200, 2000, Easing.BounceIn);
                            }

            else if (a == 15)
            {
                await Navigation.PushAsync(new frontpage());
                timer.Stop();
            }
        }

        protected override async void OnAppearing()
        {

            a = 0;
            // await img.TranslateTo(0, 200, 2000, Easing.BounceIn);
            await img1.RotateTo(360, 2000, Easing.SinInOut);
            await img.TranslateTo(0, 200, 2000, Easing.BounceIn);
            timer=new Timer(TimeSpan.FromSeconds(2).TotalMilliseconds) { AutoReset=true,Enabled=true};
            //timer.Start();
            timer.Elapsed += timer_Elaspsed;
            base.OnAppearing();
        }

    }
}