using Newtonsoft.Json;
using School.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace School.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Student> StudentList { get; set; } = new ObservableCollection<Student>();

        private List<Student> studentList2;
        public List<Student> StudentList2
        {
            get { return studentList2; }
            set { studentList2 = value; OnPropertyChanged(nameof(StudentList2)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public MainPage()
        {
            this.InitializeComponent();
            StudentList2 = new List<Student>();
        }
        private async void ShowStudents(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61295/api/");

                var json = await client.GetStringAsync("Student").ConfigureAwait(false);
                var students = JsonConvert.DeserializeObject<List<Student>>(json);


                foreach (Student s in students)
                {
                    StudentList2.Add(s);
                }
            }

        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {

        }

        private void ShowCourses(object sender, RoutedEventArgs e)
        {

        }

        private void AddCourse(object sender, RoutedEventArgs e)
        {

        }


    }
}






















//await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, (() =>
