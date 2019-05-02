using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using RedditPost.Base;
using RedditPost.Models;
using RedditPost.Views;

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
                string jsonFileName = "RedditData.json";
                var assembly = typeof(MainPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();

                    Item = JsonConvert.DeserializeObject<TopModel>(jsonString);
                }
            }
            catch (Exception ex)
            {
                await DisplayError(ex);
            }
        }
    }
}
