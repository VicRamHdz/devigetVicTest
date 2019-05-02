using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using RedditPost.Views;
using Xamarin.Forms;

namespace RedditPost.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public async Task DisplayError(Exception ex)
        {
            //Showing error to console
            Console.WriteLine(ex.ToString());

            //Display general error
            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MessagingCenter.Send<string, string>("Error", "DisplayError", ex.Message);
                });
            });
        }

    }
}
