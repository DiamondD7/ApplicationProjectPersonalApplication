using PhotoGall.Model;
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
    public partial class AlbumDetailPage : ContentPage
    {
        public event EventHandler<AlbumModel> AlbumAdded;
        public event EventHandler<AlbumModel> AlbumUpdated;
        public AlbumDetailPage(AlbumModel album)
        {
            if(album == null)
            {
                return;
            }
            InitializeComponent();
            BindingContext = new AlbumModel
            {
                Name = album.Name,
                Id = album.Id
            };
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var album = BindingContext as AlbumModel;
            if (String.IsNullOrWhiteSpace(album.Name))
            {
                return;
            }
            if (album.Id == 0)
            {
                album.Id = 1;
                AlbumAdded?.Invoke(this, album);
            }
            else
            {
                AlbumUpdated?.Invoke(this, album);
            }
            await Navigation.PopModalAsync();
        }
    }
}