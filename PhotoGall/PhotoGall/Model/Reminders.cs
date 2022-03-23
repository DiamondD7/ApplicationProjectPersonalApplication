using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace reminders.Model
{
    public class Reminders
    {
        public string Title { get; set; }
        public string description { get; set; }
        public int Id { get; set; }
        public string TitleandDescription
        {
            get { return $"{Title} {description}"; }
        }
        public DateTime now
        {
            get { return DateTime.Now; }
        }
    }
}
