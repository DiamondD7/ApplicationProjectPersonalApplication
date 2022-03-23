using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoGall
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            Profile.IsEnabled = false;
            Profile.Opacity = 0.5;
        }

        private void Album_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AlbPage();
        }

        private void Calendar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CalendarPage();
        }
    }
}