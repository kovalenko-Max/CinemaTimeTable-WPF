using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTimeTableLibrary
{
    public class TimeTableCreator
    {
        public IEnumerable<Movie> Movies { get; set; }
        public WorkDay WorkDay { get; set; }
        public TimeTable BestTimeTable { get; set; }

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

        public override string ToString()
        {
            return BestTimeTable.ToString();
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void FindBestTimeTable(TimeSpan time, TimeTable currentTimeTable)
        {
            foreach (Movie movie in Movies)
            {
                if (movie.Duration <= currentTimeTable.TimeLeft)
                {
                    currentTimeTable.MoviesByTime.Add(time, movie);
                    currentTimeTable.TimeLeft -= movie.Duration;
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
            double errorCoef = 120;
            double timeLeftError = WorkDay.TimeLeft.TotalSeconds / errorCoef;

            bool isTimeLeftLessThanError = currentTimeTable.TimeLeft.TotalSeconds < timeLeftError
                || currentTimeTable.TimeLeft < BestTimeTable.TimeLeft;

            return currentTimeTable.countOfDifferentMovies > BestTimeTable.countOfDifferentMovies
                && isTimeLeftLessThanError;
        }
    }
}
