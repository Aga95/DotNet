using GymBuddy.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GymBuddy.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Profile> ProfileList;

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void AddDay(object sender, RoutedEventArgs e)
        {
            string ExName = Name.Text;
            int lifted = int.Parse(Lifted.Text);
            string sets = Sets.Text;

            int dateDay = Dates.Date.Day;
            int dateMonth = Dates.Date.Month;
            int dateYear = Dates.Date.Year;

            var p = (Profile)ProfileCB.SelectedValue;


            SetExercise(ExName, lifted, int.Parse(sets));
            SetDay(dateDay, dateMonth, dateYear, ExName, (p.FirstName + " " + p.LastName));

            Name.Text = "";
            Lifted.Text = "";
            Sets.Text = "";
        }

        private async void SetDay(int dateDay, int dateMonth, int dateYear, string ExName, string ProfileName)
        {
            Day d = new Day(1, dateDay, dateMonth, dateYear, ExName, ProfileName);

            var payloadD = await Task.Run(() => JsonConvert.SerializeObject(d));

            var httpContentD = new StringContent(payloadD, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var httpResponseD = await client.PostAsync("http://localhost:53713/api/Days", httpContentD);

                if (httpResponseD.Content != null)
                {
                    var responseContentD = await httpResponseD.Content.ReadAsStringAsync();
                }
            }
        }
        private async void SetExercise(string ExName, int lifted, int sets)
        {
            Exercise ex = new Exercise(1, ExName, lifted, sets);

            var payloadE = await Task.Run(() => JsonConvert.SerializeObject(ex));

            var httpContentE = new StringContent(payloadE, Encoding.UTF8, "application/json");


            using (var client = new HttpClient())
            {
                var httpResponseE = await client.PostAsync("http://localhost:53713/api/Exercises", httpContentE);


                if (httpResponseE != null)
                {
                    var responseContentE = await httpResponseE.Content.ReadAsStringAsync();
                }

            }
        }

        private void GoToLogg(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Logg));
        }

        private void GoToProfile(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProfilePage));
        }

        private async void GetProfiles()
        {
            dynamic profiles;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53713/api/");
                var json = await client.GetStringAsync("Profiles").ConfigureAwait(false);
                profiles = JsonConvert.DeserializeObject<List<Profile>>(json);
            }
            ProfileList = new ObservableCollection<Profile>();
            foreach (Profile p in profiles)
            {
                ProfileList.Add(p);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetProfiles();
            ProfileCB.ItemsSource = ProfileList;
        }
    }
}
