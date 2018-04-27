using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBuddy.Model
{
    public class Day
    {
        public int DayId { get; set; }

        public int DateDay { get; set; }

        public int DateMonth { get; set; }

        public int DateYear { get; set; }

        public string ExerciseName { get; set; }

        public string ProfileName { get; set; }

        public Day(int dayId, int dateDay, int dateMonth, int dateYear, string exerciseName, string profileName)
        {
            this.DayId = dayId;
            this.DateDay = dateDay;
            this.DateMonth = dateMonth;
            this.DateYear = dateYear;
            this.ExerciseName = exerciseName;
            this.ProfileName = profileName;
        }
        public Day()
        {

        }
    }
}
