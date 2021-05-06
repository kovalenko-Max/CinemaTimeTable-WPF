﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTableLibrary
{
    public struct TimeTable : ICloneable
    {
        public Dictionary<TimeSpan, Movie> MoviesByTime;
        public TimeSpan TimeLeft;
        public int countOfDifferentMovies 
        { 
            get
            {
                return GetCountOfDifferentMovies();
            }
            private set
            { 
            } 
        }

        public TimeTable(TimeSpan timeLeft)
        {
            TimeLeft = timeLeft;
            MoviesByTime = new Dictionary<TimeSpan, Movie>();
            countOfDifferentMovies = GetCountOfDifferentMovies();
        }

        public TimeTable(Dictionary<TimeSpan,Movie> moviesByTime, TimeSpan timeLeft)
        {
            MoviesByTime = moviesByTime;
            TimeLeft = timeLeft;
            countOfDifferentMovies = GetCountOfDifferentMovies();
        }

        private int GetCountOfDifferentMovies()
        {
            return Enumerable.Distinct(MoviesByTime.Values.ToArray()).Count();
        }

        public object Clone()
        {
            return new TimeTable(new Dictionary<TimeSpan, Movie>(MoviesByTime), TimeLeft);
        }
    }
}
