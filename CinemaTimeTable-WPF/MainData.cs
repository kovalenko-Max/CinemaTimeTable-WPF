using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaTimeTable_WPF.Cinemas;

namespace CinemaTimeTable_WPF
{
    public class MainData
    {
        public List<MovieСard> MovieCards { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public List<CinemaHall> CinemaHalls { get; set; }

        public ObservableCollection<MovieСard> MoviesByTime;
        public TimeSpan WorkTimeDuration { get; set; }

        private static MainData _mainData;
        private MainData()
        {
            Movies = new ObservableCollection<Movie>();
            MoviesByTime = new ObservableCollection<MovieСard>();
            MovieCards = new List<MovieСard>();
            CinemaHalls = new List<CinemaHall>();
            CinemaHalls.Add(new CinemaHall(WorkTimeDuration, Movies));
            Cinema cinema = new Cinema(CinemaHalls, Movies);
        }

        public static MainData GetMainData()
        {
            if (_mainData is null)
            {
                return _mainData = new MainData();
            }
            else
            {
                return _mainData;
            }
        }
    }
}
