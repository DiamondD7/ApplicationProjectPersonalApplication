using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhotoGall
{
    public partial class MainPage : ContentPage
    {
        int count;
        public string temp;
        public string lbl;

        private string[] pics = new string[]
        {
            "https://www.apa.org/images/healthy-relationships-title-image_tcm7-213338.jpg",
            "https://www.incimages.com/uploaded_files/image/1920x1080/getty_516375011_2000133320009280163_199626.jpg",
            "https://i.pinimg.com/originals/10/fd/8e/10fd8e72f55240e0be52ba7914a1f526.jpg",
            "https://thoughtcatalog.com/wp-content/uploads/2020/01/x-adorable-instagram-captions-for-your-couples-photos-in-2020.jpg?w=1920&h=1280&crop=1",
            "https://i.pinimg.com/originals/82/ca/7b/82ca7b0826fdbe99cc490c55e4b85388.jpg",
            "https://i.pinimg.com/736x/c2/21/79/c22179299b0d504207d9f560cf8ac330.jpg",
        };

        private void getPics(int c)
        {
            var imageSource = new UriImageSource { Uri = new Uri(pics[c]) };
            imageSource.CachingEnabled = false;
            img.Source = imageSource;
        }

        public MainPage()
        {
            InitializeComponent();
            count = 0;
            changeLabels(count);
            getPics(count);

            Album.IsEnabled = false;
            Album.Opacity = 0.5;

        }

        private void leftbtn_Clicked(object sender, EventArgs e)
        {
            if (count == 0)
            {
                count = 0;
            }
            else
            {
                count--;
            }
            changeLabels(count);
            getPics(count);
            
        }

        private void rightbtn_Clicked(object sender, EventArgs e)
        {
            count++;
            if (count == 6)
            {
                count = 0;
                
            }
            changeLabels(count);
            getPics(count);
            
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage();
        }

        private void Calendar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CalendarPage();
        }

        private void entr_Completed(object sender, EventArgs e)
        {

            if (descriptionlbl.IsVisible == true)
            {
                temp = entr.Text;
                descriptionlbl.Text += " " + temp;

            }
            else if (description2lbl.IsVisible == true)
            {
                temp = entr.Text;
                description2lbl.Text += " " + temp;
            }
            else if (description3lbl.IsVisible == true)
            {
                temp = entr.Text;
                description3lbl.Text += " " + temp;
            }
            else if (description4lbl.IsVisible == true)
            {
                temp = entr.Text;
                description4lbl.Text += " " + temp;
            }
            else if (description5lbl.IsVisible == true)
            {
                temp = entr.Text;
                description5lbl.Text += " " + temp;
            }
            else if (description6lbl.IsVisible == true)
            {
                temp = entr.Text;
                description6lbl.Text += " " + temp;
            }
            entr.Text = "";
        }
        
        private void changeLabels(int c)
        {
            if (c == 0)
            {
                descriptionlbl.IsVisible = true;
                description2lbl.IsVisible = false;
                description3lbl.IsVisible = false;
                description4lbl.IsVisible = false;
                description5lbl.IsVisible = false;
                description6lbl.IsVisible = false;

            }
            else if (c == 1)
            {
                descriptionlbl.IsVisible = false;
                description2lbl.IsVisible = true;
                description3lbl.IsVisible = false;
                description4lbl.IsVisible = false;
                description5lbl.IsVisible = false;
                description6lbl.IsVisible = false;
            }
            else if (c == 2)
            {
                descriptionlbl.IsVisible = false;
                description2lbl.IsVisible = false;
                description3lbl.IsVisible = true;
                description4lbl.IsVisible = false;
                description5lbl.IsVisible = false;
                description6lbl.IsVisible = false;
            }
            else if (c == 3)
            {
                descriptionlbl.IsVisible = false;
                description2lbl.IsVisible = false;
                description3lbl.IsVisible = false;
                description4lbl.IsVisible = true;
                description5lbl.IsVisible = false;
                description6lbl.IsVisible = false;
            }
            else if (c == 4)
            {
                descriptionlbl.IsVisible = false;
                description2lbl.IsVisible = false;
                description3lbl.IsVisible = false;
                description4lbl.IsVisible = false;
                description5lbl.IsVisible = true;
                description6lbl.IsVisible = false;
            }
            else if (c == 5)
            {
                descriptionlbl.IsVisible = false;
                description2lbl.IsVisible = false;
                description3lbl.IsVisible = false;
                description4lbl.IsVisible = false;
                description5lbl.IsVisible = false;
                description6lbl.IsVisible = true;
            }


        }

        private void clearbtn_Clicked(object sender, EventArgs e)
        {
            if(count == 0)
            {
                descriptionlbl.Text = "";
                
            }
            else if (count == 1)
            {
                description2lbl.Text = "";
            }
            else if (count == 2)
            {
                description3lbl.Text = "";
            }
            else if (count == 4)
            {
                description4lbl.Text = "";
            }
            else if (count == 5)
            {
                description5lbl.Text = "";
            }
            else if (count == 5)
            {
                description6lbl.Text = "";
            }
        }
    }
}
