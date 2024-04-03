using Newtonsoft.Json;
using UnInfoApp.Code;
using UnInfoApp.Models;

namespace UnInfoApp
{
    public partial class MainPage : ContentPage
    {
        private List<Rootobject> roobjects;
        private HttpHelper httpHelper;

        public MainPage()
        {
            InitializeComponent();
            roobjects = new List<Rootobject>();
            httpHelper = new HttpHelper();
        }

        private void ButtonSearch_Clicked(object sender, EventArgs e)
        {
            if (countryName.Text != null)
            {
                LoadData(countryName.Text);
            }
        }

        private async void LoadData(string countryName)
        {
            // Clear
            roobjects.Clear();
            ConLayout.Clear();

            // Get Response and Fill root UN !
            IndicatorLoading.IsVisible = true; IndicatorLoading.IsRunning = true;
            var response = await httpHelper.GetResponseAsync("http://universities.hipolabs.com/search?country=" + countryName);
            roobjects = JsonConvert.DeserializeObject<List<Rootobject>>(response);

            // For loop into rootobjects !
            for (int i = 0; i < roobjects.Count; i++)
            {
                var item = roobjects[i];
                ConLayout.Add(new Views.UnInfoView(item.name, item.web_pages[0]));
            }
            IndicatorLoading.IsVisible = false; IndicatorLoading.IsRunning = false;
        }
    }

}
