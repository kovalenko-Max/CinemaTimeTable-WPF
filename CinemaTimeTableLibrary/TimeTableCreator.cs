using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTableLibrary
{
    public class TimeTableCreator
    {
        public IEnumerable<Movie> Movies;
        public TimeSpan StartTime;
        public TimeSpan EndTime;

        public TimeTable BestTimeTable;
        

        public TimeTableCreator(ObservableCollection<Movie> movies, TimeSpan endTime)
        {
            StartTime = new TimeSpan(10, 0, 0);
            Movies = movies;
            EndTime = endTime;
            
            BestTimeTable = new TimeTable(EndTime - StartTime);
        }

        public void CreateTimeTable()
        {
            TimeSpan leftTime = EndTime - StartTime;
            FindBestTimeTable(leftTime, StartTime, new TimeTable(leftTime));
        }

        private void FindBestTimeTable(TimeSpan timeLeft, TimeSpan time, TimeTable currentTimeTable)
        {
            foreach (Movie movie in Movies)
            {
                if (movie.Duration <= timeLeft)
                {
                    TimeTable newTimeTable = (TimeTable)currentTimeTable.Clone();
                    newTimeTable.MoviesByTime.Add(time, movie);
                    TimeSpan newTimeLeft = timeLeft - movie.Duration;
                    newTimeTable.TimeLeft = newTimeLeft;

                    FindBestTimeTable(newTimeLeft, time + movie.Duration, newTimeTable);
                }
                else
                {
                    if (IsCurrentTimeTableBetter(currentTimeTable))
                    {
                        BestTimeTable = currentTimeTable;
                    }
                }
            }
        }

        private bool IsCurrentTimeTableBetter(TimeTable currentTimeTable)
        {
            return currentTimeTable.TimeLeft <= BestTimeTable.TimeLeft 
                && currentTimeTable.countOfDifferentMovies > BestTimeTable.countOfDifferentMovies;
        }
    }
}
