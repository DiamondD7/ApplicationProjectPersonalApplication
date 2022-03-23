using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using reminders.Model;

namespace PhotoGall
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public ObservableCollection<Reminders> _reminders;
        public CalendarPage()
        {
            InitializeComponent();
            _reminders = new ObservableCollection<Reminders>
            {
                new Reminders { Id = 1, Title = "Something", description = "Nice one!"}
            };
            ListView.ItemsSource = _reminders;
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new ProfilePage();
        }

        private void Album_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new AlbPage();
        }

        async void addBtn_Clicked(object sender, EventArgs e)
        {
            var page = new RemindersDetailPage(new Reminders());
            page.ReminderAdded += (source, reminders) =>
            {
                _reminders.Add(reminders);
            };
            await Navigation.PushModalAsync(page);
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            if (ListView.SelectedItem == null)
            {
                return;
            }
            ListView.SelectedItem = null;
            var selectedItem = e.SelectedItem as Reminders;
            var page = new RemindersDetailPage(selectedItem);
            page.ReminderUpdated += (source, reminders) =>
            {
                selectedItem.Title = reminders.Title;
                selectedItem.description = reminders.description;
                selectedItem.Id = reminders.Id;
            };
            await Navigation.PushModalAsync(page);

        }

        async void deleteBtn_Clicked(object sender, EventArgs e)
        {
            var reminder = (sender as MenuItem).CommandParameter as Reminders;
            if (await DisplayAlert("Warning", $"Are you sure you want to delete {reminder.Title}?", "Yes", "No"))
            {
                _reminders.Remove(reminder);
            }
        }
    }
}