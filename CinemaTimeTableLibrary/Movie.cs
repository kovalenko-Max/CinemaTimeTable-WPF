using System;

namespace CinemaTimeTableLibrary
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
            Description = string.Empty;
        }

        public object Clone()
        {
            Movie cloneMovie = new Movie(Name, Duration);
            cloneMovie.Description = Description;
            return cloneMovie;
        }

        public override string ToString()
        {
            return $"{Name} ({Duration.ToString(@"hh\:mm")})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Movie)
            {
                Movie comparedMovie = (Movie)obj;
                return Name.Equals(comparedMovie.Name)
                    && Description.Equals(comparedMovie.Description)
                    && Duration == comparedMovie.Duration;
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
    }
}

