using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTable_WPF.Cinemas
{
    public class CinemaHall
    {
        public TimeSpan WorkDayDuration { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public TimeTable TimeTable { get; set; }

        public CinemaHall(TimeSpan workDayDuration, ObservableCollection<Movie> movies)
        {
            WorkDayDuration = workDayDuration;
            Movies = movies;
        }

        public void CreateTimeTable()
        {
            TimeTable = new TimeTable(Movies);
            TimeTable.CreateTimeTable();
        }
    }
}
