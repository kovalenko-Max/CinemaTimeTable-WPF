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
        public int count = 0;

        public TimeTableCreator(IEnumerable<Movie> movies, WorkDay workDay)
        {
            Movies = movies;
            WorkDay = workDay;
            BestTimeTable = new TimeTable(WorkDay.TimeLeft);
        }

        public void CreateTimeTable()
        {
            TimeSpan leftTime = WorkDay.TimeLeft;
            FindBestTimeTable(WorkDay.TimeOfStart, new TimeTable(leftTime));
        }

        public override bool Equals(object obj)
        {
            if (obj is TimeTableCreator)
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

        private void FindBestTimeTable(TimeSpan time, TimeTable currentTimeTable)
        {
            foreach (Movie movie in Movies)
            {
                if (movie.Duration <= currentTimeTable.TimeLeft)
                {
                    currentTimeTable.MoviesByTime.Add(time, movie);
                    currentTimeTable.TimeLeft -= movie.Duration;
                    ++count;
                    FindBestTimeTable(time + movie.Duration, currentTimeTable);

                    if (currentTimeTable.MoviesByTime.Count > 0)
                    {
                        currentTimeTable.TimeLeft += currentTimeTable.MoviesByTime[currentTimeTable.MoviesByTime.Keys.Last()].Duration;
                        currentTimeTable.MoviesByTime.Remove(currentTimeTable.MoviesByTime.Keys.Last());
                    }
                }
                else
                {
                    if (IsCurrentTimeTableBetter(currentTimeTable))
                    {
                        BestTimeTable = (TimeTable)currentTimeTable.Clone();
                    }
                }
            }

        }

        private bool IsCurrentTimeTableBetter(TimeTable currentTimeTable)
        {
            return currentTimeTable.countOfDifferentMovies > BestTimeTable.countOfDifferentMovies
                && currentTimeTable.TimeLeft <= BestTimeTable.TimeLeft;
        }
    }
}
