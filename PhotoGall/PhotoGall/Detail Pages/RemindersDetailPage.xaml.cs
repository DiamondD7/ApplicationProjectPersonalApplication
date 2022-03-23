using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using reminders.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoGall
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemindersDetailPage : ContentPage
    {
        public event EventHandler<Reminders> ReminderAdded;
        public event EventHandler<Reminders> ReminderUpdated;
        public RemindersDetailPage(Reminders reminders)
        {
            if(reminders == null)
            {
                return;
            }
            InitializeComponent();
            BindingContext = new Reminders
            {
                Id = reminders.Id,
                Title = reminders.Title,
                description = reminders.description                 
            };
        }

        async void saveBtn_Clicked(object sender, EventArgs e)
        {
            var reminder = BindingContext as Reminders;
            if (String.IsNullOrWhiteSpace(reminder.TitleandDescription))
            {
                return;
            }

            if(reminder.Id == 0)
            {
                reminder.Id = 1;
                ReminderAdded?.Invoke(this, reminder);
            }
            else
            {
                ReminderUpdated?.Invoke(this, reminder);
            }

            await Navigation.PopModalAsync();
        }
    }
}