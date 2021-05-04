using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTable_WPF.Cinema
{
    public class CinemaHall
    {
        public int WorkDayDuration { get; set; }
        public List<Movie> Movies { get; set; }
        public TimeTable TimeTable { get; set; }

        public CinemaHall(int workDayDuration, List<Movie> movies)
        {
            WorkDayDuration = workDayDuration;
            Movies = movies;
        }

        public void CreateTimeTable()
        {
            TimeTable timeTable = new TimeTable(Movies);
            timeTable.CreateTimeTable();
        }
    }
}
