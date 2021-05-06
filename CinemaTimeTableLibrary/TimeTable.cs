using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTableLibrary
{
    public class TimeTable
    {
        public ObservableCollection<Movie> Movies;

        public Node Graph;

        public Dictionary<TimeSpan, Movie> TimeTableElement;
        public TimeTable(ObservableCollection<Movie> movies)
        {
            Movies = movies;
        }

        public void CreateTimeTable()
        {
            Graph = new Node(new TimeSpan(14,0,0), new TimeSpan(10, 0, 0), Movies);
            Graph.CreateGraph();
            
            Node optimalBranch = Graph.SelectOptinalBranch();

            TimeTableElement = new Dictionary<TimeSpan, Movie>();
            foreach(Node s in optimalBranch.AllPreviousMovies)
            {
                TimeTableElement.Add(s.Time, s.Movie);
            }
        }
    }
}
