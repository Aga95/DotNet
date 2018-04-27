using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class Day
    {
        public int Id;

        public int DateDay;

        public int DateMonth;

        public Day(int dayId, int dateDay, int dateMonth)
        {
            this.Id = dayId;
            this.DateDay = dateDay;
            this.DateMonth = dateMonth;
        }
    }
}
