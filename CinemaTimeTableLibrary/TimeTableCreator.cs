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
        public WorkDay WorkDay;
        public TimeTable BestTimeTable;
        
        public TimeTableCreator(IEnumerable<Movie> movies, WorkDay workDay)
        {
            Movies = movies;
            WorkDay = workDay;
            BestTimeTable = new TimeTable(WorkDay.TimeLeft);
        }

        public void CreateTimeTable()
        {
            TimeSpan leftTime = WorkDay.TimeLeft;
            FindBestTimeTable(leftTime, WorkDay.TimeOfStart, new TimeTable(leftTime));
        }

        public override bool Equals(object obj)
        {
            if(obj is TimeTableCreator)
            {
                TimeTableCreator comparedTimeTableCreator = (TimeTableCreator)obj;

                return WorkDay.Equals(comparedTimeTableCreator.WorkDay)
                    && BestTimeTable.Equals(comparedTimeTableCreator.BestTimeTable);
            }
            else
            {
                return false;
            }
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
