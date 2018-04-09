using Newtonsoft.Json;
using School.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Student> StudentList  = new ObservableCollection<Student>();
        public ObservableCollection<Course> CourseList = new ObservableCollection<Course>();


        public MainPage()
        {
            this.InitializeComponent();
            ShowStudents();
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
        }

        private void AddCourse(object sender, RoutedEventArgs e)
        {
        }

        public void UpdateLists()
        {
            ShowStudents();
        }
        public async void ShowStudents()
        {
            dynamic students;
            using (var clients = new HttpClient())
            {
                clients.BaseAddress = new Uri("http://localhost:61295/api/");

                var json = await clients.GetStringAsync("Student").ConfigureAwait(false);
                students = JsonConvert.DeserializeObject<List<Student>>(json);
               
            }

            foreach (Student s in students)
            {
                StudentList.Add(s);
            }
            studentViewList.ItemsSource = StudentList;
        }

    }
}
