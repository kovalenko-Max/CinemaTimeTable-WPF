using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTimeTable_WPF.Cinemas
{
    public class Cinema
    {
        public List<CinemaHall> CinemaHalls { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }

        public Cinema()
        {
            CinemaHalls = new List<CinemaHall>();
            Movies = new ObservableCollection<Movie>();
        }

        public Cinema(List<CinemaHall> cinemaHalls, ObservableCollection<Movie> movies)
        {
            CinemaHalls = cinemaHalls;
            Movies = movies;
        }
    }
}
