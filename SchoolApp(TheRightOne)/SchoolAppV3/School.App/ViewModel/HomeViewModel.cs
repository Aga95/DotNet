using Newtonsoft.Json;
using School.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace School.App.ViewModel
{
    public class HomeViewModel : Bindable
    {
        public HomeViewModel()
        {
            StudentList = new List<Student>();
            
        }

        

        private List<Student> studentList;
        public List<Student> StudentList
        {
            get { return studentList; }
            set { studentList = value; OnPropertyChanged(nameof(StudentList)); }
        }

        public async void GetStudents()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61295/api/");

                var json = await client.GetStringAsync("Student").ConfigureAwait(false);
                var students = JsonConvert.DeserializeObject<List<Student>>(json);


                foreach (Student s in students)
                {
                    StudentList.Add(s);
                }
            }
        }

    }
}
