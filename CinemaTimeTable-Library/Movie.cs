using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTable_WPF.Cinemas
{
    public class Movie : ICloneable
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }

        public Movie(string name, TimeSpan duration)
        {
            Name = name;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Name} ({Duration})";
        }

        public object Clone()
        {
            Movie cloneMovie = new Movie(Name, Duration);
            cloneMovie.Description = Description;
            return cloneMovie;
        }
    }
}

