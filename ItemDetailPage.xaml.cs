using EventPlanner.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EventPlanner.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}