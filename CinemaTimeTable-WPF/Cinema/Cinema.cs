using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTable_WPF.Cinema
{
    public class Cinema
    {
        public List<CinemaHall> CinemaHalls { get; set; }
        public List<Movie> Movies { get; set; }

        public Cinema()
        {
            CinemaHalls = new List<CinemaHall>();
            Movies = new List<Movie>();
        }

        public Cinema(List<CinemaHall> cinemaHalls, List<Movie> movies)
        {
            CinemaHalls = cinemaHalls;
            Movies = movies;
        }
    }
}
