using GymBuddy.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Windows;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GymBuddy.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Logg : Page
    {
        private ObservableCollection<Exercise> ExerciseList;

        private ObservableCollection<Day> DayList;

        private ObservableCollection<Profile> ProfileList;

        public Logg()
        {
            this.InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void UpdateDayLists(object sender, RoutedEventArgs e)
        {
            if(ProfileCB.SelectedValue != null)
            {
                var profile = (Profile)ProfileCB.SelectedValue;
                GetFromdatabaseDay(profile);
                dayViewList.ItemsSource = DayList;
            }
        }

        private async void GetFromdatabaseExercise(Day day)
        {
            dynamic exercises;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53713/api/");
                var json = await client.GetStringAsync("Exercises").ConfigureAwait(false);
                exercises = JsonConvert.DeserializeObject<List<Exercise>>(json);
            }
            ExerciseList = new ObservableCollection<Exercise>();
            foreach (Exercise e in exercises)
            {
                if (e.Name == day.ExerciseName)
                {
                    ExerciseList.Add(e);
                }
            }
        }

        private async void GetFromdatabaseDay(Profile profile)
        {
            dynamic days;
            string profileName = profile.FirstName + " " + profile.LastName;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53713/api/");
                var json = await client.GetStringAsync("Days").ConfigureAwait(false);
                days = JsonConvert.DeserializeObject<List<Day>>(json);
            }
            DayList = new ObservableCollection<Day>();
            foreach (Day d in days)
            {
                if (profileName == d.ProfileName)
                {
                    DayList.Add(d);
                }
            }
        }

        private async void GetFromdatabaseProfile()
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

        private void GoToProfile(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProfilePage));
        }

        private void UpdateProfile(object sender, RoutedEventArgs e)
        {
            GetFromdatabaseProfile();
            ProfileCB.ItemsSource = ProfileList;
        }

        private void UpdateExercisesList(object sender, RoutedEventArgs e)
        {
            var day = (Day)dayViewList.SelectedItem;
            GetFromdatabaseExercise(day);
            exerciseViewList.ItemsSource = ExerciseList;  
        }
    }
}
