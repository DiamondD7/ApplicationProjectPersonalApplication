using PhotoGall.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoGall
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbPage : ContentPage
    {
        public ObservableCollection<AlbumModel> _albModel;
        public AlbPage()
        {
            InitializeComponent();
            _albModel = new ObservableCollection<AlbumModel>
            {
                new AlbumModel {Id = 1, Name = "Album"}
            };
            albumList.ItemsSource = _albModel;

        }

        async void Add_Clicked(object sender, EventArgs e)
        {
            var page = new AlbumDetailPage(new AlbumModel());
            page.AlbumAdded += (source, album) =>
            {
                _albModel.Add(album);
            };
            await Navigation.PushModalAsync(page);
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage();
        }

        private void Calendar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CalendarPage();
        }

        async void albumList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (albumList.SelectedItem == null)
            {
                return;
            }
            albumList.SelectedItem = null;
            var selectedItem = e.CurrentSelection.FirstOrDefault() as AlbumModel;
            var page = new AlbumDetailPage(selectedItem);
            page.AlbumUpdated += (source, album) =>
            {
                selectedItem.Id = album.Id;
                selectedItem.Name = album.Name;
            };

            await Navigation.PushModalAsync(page);
        }
    }
}