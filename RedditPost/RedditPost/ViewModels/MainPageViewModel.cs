using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using RedditPost.Base;
using RedditPost.Models;
using RedditPost.Views;
using Xamarin.Forms;

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

        private Data2 _selected;
        public Data2 selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectItemCommand { get; set; }
        public ICommand DismissItemCommand { get; set; }
        public ICommand DismissAllCommand { get; set; }

        public MainPageViewModel()
        {
            SelectItemCommand = new Command((p) => OnSelectedItem(p as Child));
            DismissItemCommand = new Command((p) => OnDismissItem(p as Child));
            DismissAllCommand = new Command((p) => OnDismissAll());
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

        private void OnSelectedItem(Child item)
        {
            selected = item.data;
        }

        private void OnDismissItem(Child item)
        {
            Item.data.children.Remove(item);
        }

        private void OnDismissAll()
        {
            Item.data.children.Clear();
        }
    }
}
