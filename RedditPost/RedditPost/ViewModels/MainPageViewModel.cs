using System;
using RedditPost.Base;
using RedditPost.Models;

namespace RedditPost.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private TopModel _item;
        public TopModel Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                await DisplayError(ex);
            }
        }
    }
}
