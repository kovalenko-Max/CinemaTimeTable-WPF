using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CinemaTimeTableLibrary
{
    public class CinemaHall
    {
        public WorkDay WorkDay { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public TimeTable TimeTable { get; set; }

        public CinemaHall(WorkDay workDay, ObservableCollection<Movie> movies)
        {
            WorkDay = workDay;
            Movies = movies;
        }

        public void CreateTimeTable()
        {
            TimeTableCreator timeTableCreator = new TimeTableCreator(Movies, WorkDay);
            timeTableCreator.CreateTimeTable();
            TimeTable = timeTableCreator.BestTimeTable;
        }
    }
}
