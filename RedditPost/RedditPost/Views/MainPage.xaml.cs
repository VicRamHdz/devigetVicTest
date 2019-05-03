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
        private bool IsSwiping = false;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();

            var SwipeDetail = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
            SwipeDetail.Swiped += OnSwipedDetail;
            this.stcDetails.GestureRecognizers.Add(SwipeDetail);

            var SwipeLeftDetail = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            SwipeLeftDetail.Swiped += OnSwipedLeftDetail;
            this.stcDetails.GestureRecognizers.Add(SwipeLeftDetail);

            var TapDetail = new TapGestureRecognizer();
            TapDetail.Tapped += OnTapDetail;
            this.stcDetails.GestureRecognizers.Add(TapDetail);

            var SwipeMenuLeft = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            SwipeMenuLeft.Swiped += OnSwipedMenu;
            this.Menu.GestureRecognizers.Add(SwipeMenuLeft);
        }

        void OnSwipedDetail(object sender, SwipedEventArgs e)
        {
            IsSwiping = true;
            switch (e.Direction)
            {
                case SwipeDirection.Right:
                    Menu.IsVisible = true;
                    break;
            }
            IsSwiping = false;
        }

        void OnSwipedLeftDetail(object sender, SwipedEventArgs e)
        {
            IsSwiping = true;
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    Menu.IsVisible = false;
                    break;
            }
            IsSwiping = false;
        }

        void OnTapDetail(object sender, EventArgs e)
        {
            IsSwiping = true;
            Menu.IsVisible = false;
            IsSwiping = false;
        }

        void OnSwipedMenu(object sender, SwipedEventArgs e)
        {
            IsSwiping = true;
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    // Handle the swipe
                    Menu.IsVisible = false;
                    break;
            }
            IsSwiping = false;
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
                if (!IsSwiping)
                    Menu.IsVisible = true;
            }
            else //portrait
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    this.mainGrid.Margin = new Thickness(0, 20, 0, 0);
                }
                if (!IsSwiping)
                    Menu.IsVisible = false;
            }
        }
    }
}
