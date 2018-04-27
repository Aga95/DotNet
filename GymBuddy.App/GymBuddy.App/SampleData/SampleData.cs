using GymBuddy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBuddy.App.SampleData
{
    public class SampleData
    {
        public ObservableCollection<Profile> Profiles { get; set; }

        public ObservableCollection<Day> Days { get; set; }

        public ObservableCollection<Exercise> Exercises { get; set; }

        public SampleData()
        {
            Profiles = new ObservableCollection<Profile>()
            {
                new Profile()
                {
                    Id = 1,
                    FirstName = "Test1",
                    LastName = "Test1_1",
                    Age = 33,
                    Weight = 111
                }
            };

            Exercises = new ObservableCollection<Exercise>()
            {
                new Exercise()
                {
                    Id = 1,
                    Name="Doing What",
                    Lifted=22,
                    Sets = 3
                }
            };

            Days = new ObservableCollection<Day>()
            {
                new Day()
                {
                    DayId = 1,
                    DateDay = 22,
                    DateMonth = 3,
                    DateYear = 2018,
                    ExerciseName = "Doing What",
                    ProfileName = "Test1 Test1_1"
                }
            };
                
        }
    }
}
