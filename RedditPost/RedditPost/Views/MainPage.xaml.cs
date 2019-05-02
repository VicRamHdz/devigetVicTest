using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditPost.Base;
using RedditPost.ViewModels;
using Xamarin.Forms;

namespace RedditPost.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<string, string>(this, "DisplayError", async (title, message) =>
            {
                await DisplayAlert(title, message, "OK");
            });
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Width > height) //landscape
            {
                this.mainGrid.Margin = new Thickness(0);
            }
            else //portrait
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    this.mainGrid.Margin = new Thickness(0, 20, 0, 0);
                }
            }
        }
    }
}
