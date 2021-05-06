using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTableLibrary
{
    public class Node : ICloneable
    {
        public Movie Movie;
        public TimeSpan Time;

        public Node(TimeSpan time, Movie movie)
        {
            Time = time;
            Movie = movie;
        }

        public object Clone()
        {
            return new Node(Time, (Movie)Movie.Clone());
        }
        
        public override string ToString()
        {
            return $"{Movie.Name}({Movie.Duration}) at {Time}";
        }
    }
}
