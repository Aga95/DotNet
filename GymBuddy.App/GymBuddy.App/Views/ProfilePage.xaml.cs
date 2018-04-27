using GymBuddy.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public sealed partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            this.InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void GoToLogg(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Logg));
        }

        private async void NewProfile(object sender, RoutedEventArgs e)
        {
            string fName = FName.Text;
            string eName = EName.Text;
            int age = int.Parse(Age.Text);
            int weight = int.Parse(Weight.Text);

            Profile p = new Profile(1, fName, eName, age, weight);

            var payload = await Task.Run(() => JsonConvert.SerializeObject(p));

            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var httpResponse = await client.PostAsync("http://localhost:53713/api/Profiles", httpContent);

                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                }
            }

        }

    }
}
