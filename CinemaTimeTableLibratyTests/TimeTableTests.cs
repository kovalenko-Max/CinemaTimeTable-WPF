using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }

    public class TimeTableTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            TimeSpan endTime = new TimeSpan(15, 0, 0);
            ObservableCollection<Movie> movies = new ObservableCollection<Movie>()
            {
                new Movie("a", new TimeSpan(1,30,0)),
                new Movie("b", new TimeSpan(2,0,0)),
                new Movie("c", new TimeSpan(1,55,0)),
                new Movie("d", new TimeSpan(3,0,0)),
                new Movie("e", new TimeSpan(0,5,0))
            };

            TimeTableCreator expectedTimeTable = new TimeTableCreator(movies, endTime);

            yield return new object[]
            {
                new TimeTableCreator(movies, endTime),
                expectedTimeTable
            };
        }
    }
}
