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
    public partial class AdminPag : TabbedPage
    {
        public static string fullname, userid;
        public AdminPag ()
        {
            InitializeComponent();
            AdminH.Title=" Welcome "+ fullname;
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}