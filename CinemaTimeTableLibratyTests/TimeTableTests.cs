using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using CinemaTimeTableLibrary;
using System.Collections.ObjectModel;

namespace CinemaTimeTableLibratyTests
{
    public class TimeTableTests
    {
        [TestCaseSource(typeof(TimeTableTestSource))]
        public void CreateTimeTable(TimeTableCreator actual, TimeTableCreator expected)
        {
            actual.CreateTimeTable();
            Assert.AreEqual(expected, actual);
        }
    }

    public class TimeTableTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int movieMockNumb = 0;
            IEnumerable<Movie> movies = Mocks.GetMovies(movieMockNumb);
            WorkDay workDay = new WorkDay(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0));
            TimeTableCreator actualTimeTable = new TimeTableCreator(movies, workDay);
            TimeTableCreator expectedTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable.BestTimeTable = Mocks.GetExpectedTimeTable(new int[] { 0, 0, 2, 4 }, movieMockNumb, workDay);

            yield return new object[]
            {
                actualTimeTable,
                expectedTimeTable
            };

            movieMockNumb = 1;
            movies = Mocks.GetMovies(movieMockNumb);
            workDay = new WorkDay(new TimeSpan(10, 0, 0), new TimeSpan(13, 0, 0));
            actualTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable.BestTimeTable = Mocks.GetExpectedTimeTable(new int[] { 0, 0 }, movieMockNumb, workDay);

            yield return new object[]
            {
                actualTimeTable,
                expectedTimeTable
            };

            movieMockNumb = 2;
            movies = Mocks.GetMovies(movieMockNumb);
            workDay = new WorkDay(new TimeSpan(10, 0, 0), new TimeSpan(24, 0, 0));
            actualTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable.BestTimeTable = Mocks.GetExpectedTimeTable(new int[] { 0, 0, 1, 2, 3, 4, 5 }, movieMockNumb, workDay);

            yield return new object[]
            {
                actualTimeTable,
                expectedTimeTable
            };

            movieMockNumb = 3;
            movies = Mocks.GetMovies(movieMockNumb);
            workDay = new WorkDay(new TimeSpan(10, 0, 0), new TimeSpan(16, 0, 0));
            actualTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable.BestTimeTable = Mocks.GetExpectedTimeTable(new int[] { 0, 0, 0, 0 }, movieMockNumb, workDay);

            yield return new object[]
            {
                actualTimeTable,
                expectedTimeTable
            };

            movieMockNumb = 3;
            movies = Mocks.GetMovies(movieMockNumb);
            workDay = new WorkDay(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0));
            actualTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable = new TimeTableCreator(movies, workDay);
            expectedTimeTable.BestTimeTable = Mocks.GetExpectedTimeTable(new int[] { 0, 0, 0 }, movieMockNumb, workDay);

            yield return new object[]
            {
                actualTimeTable,
                expectedTimeTable
            };
        }
    }

    public static class Mocks
    {
        public static TimeTable GetExpectedTimeTable(int[] moviesSequence, int movieMockNumb, WorkDay workDay)
        {
            IList<Movie> movies = GetMovies(movieMockNumb);
            Dictionary<TimeSpan, Movie> dictonary = new Dictionary<TimeSpan, Movie>();
            TimeTable expectedTimeTable = new TimeTable(dictonary, workDay.TimeLeft);
            TimeSpan time = workDay.TimeOfStart;

            foreach (int i in moviesSequence)
            {
                expectedTimeTable.MoviesByTime.Add(time, movies[i]);
                expectedTimeTable.TimeLeft -= movies[i].Duration;
                time += movies[i].Duration;
            }

            return expectedTimeTable;
        }

        public static IList<Movie> GetMovies(int numberOfMoviesSet)
        {
            IList<Movie> movies;

            switch (numberOfMoviesSet)
            {
                case 1:
                    movies = new ObservableCollection<Movie>()
                    {
                        new Movie("a", new TimeSpan(1,30,0)),
                        new Movie("b", new TimeSpan(2,0,0)),
                        new Movie("c", new TimeSpan(1,55,0))
                    };
                    break;

                case 2:
                    movies = new List<Movie>()
                    {
                        new Movie("a", new TimeSpan(1,30,0)),
                        new Movie("b", new TimeSpan(2,0,0)),
                        new Movie("c", new TimeSpan(1,55,0)),
                        new Movie("d", new TimeSpan(1,45,0)),
                        new Movie("e", new TimeSpan(2,20,0)),
                        new Movie("f", new TimeSpan(3,0,0)),
                        new Movie("g", new TimeSpan(1,45,0))
                    };
                    break;

                case 3:
                    movies = new List<Movie>()
                    {
                        new Movie("a", new TimeSpan(1,30,0)),
                    };
                    break;

                default:
                    movies = new ObservableCollection<Movie>()
                    {
                        new Movie("a", new TimeSpan(1,30,0)),
                        new Movie("b", new TimeSpan(2,0,0)),
                        new Movie("c", new TimeSpan(1,55,0)),
                        new Movie("d", new TimeSpan(3,0,0)),
                        new Movie("e", new TimeSpan(0,5,0))
                    };
                    break;
            }

            return movies;
        }
    }
}
