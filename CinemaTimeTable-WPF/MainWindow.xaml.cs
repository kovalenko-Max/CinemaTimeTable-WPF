using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaTimeTable_WPF.Cinemas;

namespace CinemaTimeTable_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainData _mainData;
        public MainWindow()
        {
            InitializeComponent();
            _mainData = MainData.GetMainData();
            MovieListBox.ItemsSource = _mainData.Movies;
            TimeTableList.ItemsSource = _mainData.MoviesByTime;
            int workTimeDuration = Convert.ToInt32(WorkTimeTo.Text) - Convert.ToInt32(WorkTimeFrom.Text);
            _mainData.WorkTimeDuration = new TimeSpan(workTimeDuration, 0, 0);
        }

        private void AddMovie_Click(object sender, RoutedEventArgs e)
        {
            AddMovieDialog addMovieDialog = new AddMovieDialog();
            addMovieDialog.Show();
        }

        private void WorkTimeFrom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CreateTimeTable_Click(object sender, RoutedEventArgs e)
        {
            _mainData.CinemaHalls[0].CreateTimeTable();
            _mainData.MoviesByTime = new ObservableCollection<MovieСard>();
            TimeTableList.ItemsSource = _mainData.MoviesByTime;

            foreach (var movie in _mainData.CinemaHalls[0].TimeTable.TimeTableElement)
            {
                MovieСard movieСard = new MovieСard(movie.Key, movie.Value);
                string time = (movie.Key + movie.Value.Duration).ToString();
                movieСard.movieTime.Text += " - " + time;
                _mainData.MoviesByTime.Add(movieСard);
            }
        }
    }
}
