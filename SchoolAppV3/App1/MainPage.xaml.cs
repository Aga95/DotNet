using Newtonsoft.Json;
using School.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Student> StudentList;
        public ObservableCollection<Course> CourseList;

        public MainPage()
        {
            this.InitializeComponent();
            GetDatabaseStudents();
            GetDatabaseCourses();
        }

        private void ShowData(object sender, RoutedEventArgs e)
        {
            studentViewList.ItemsSource = StudentList;
            courseViewList.ItemsSource = CourseList;
        }
        private async void AddStudent(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            Student s = new Student(0, firstName, lastName);
            var payload = await Task.Run(() => JsonConvert.SerializeObject(s));
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

            using(var client = new HttpClient())
            {
                var httpResponse = await client.PostAsync("http://localhost:61295/api/Student", httpContent);

                if(httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                }
            }
            GetDatabaseStudents();
        }

        private async void AddCourse(object sender, RoutedEventArgs e)
        {
            string courseName = CourseName.Text;
            Course c = new Course(0, courseName);
            var payload = await Task.Run(() => JsonConvert.SerializeObject(c));
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var httpResponse = await client.PostAsync("http://localhost:61295/api/Course", httpContent);

                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                }
            }
            GetDatabaseCourses();
        }

        public async void GetDatabaseStudents()
        {
            dynamic students;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61295/api/");

                var json = await client.GetStringAsync("Student").ConfigureAwait(false);
                students = JsonConvert.DeserializeObject<List<Student>>(json);
               
            }
            StudentList = new ObservableCollection<Student>();
            foreach (Student s in students)
            {
                StudentList.Add(s);
            }
            
        }
        public async void GetDatabaseCourses()
        {
            dynamic courses;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61295/api/");

                var json = await client.GetStringAsync("Course").ConfigureAwait(false);
                courses = JsonConvert.DeserializeObject<List<Course>>(json);

            }
            CourseList = new ObservableCollection<Course>();
            foreach (Course c in courses)
            {
                CourseList.Add(c);
            }

        }

    }
}
