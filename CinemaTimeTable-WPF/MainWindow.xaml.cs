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
using CinemaTimeTableLibrary;

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
            _mainData.CinemaHalls = new List<CinemaHall>();
            _mainData.WorkDay = CreateWorkDay();
            _mainData.CinemaHalls.Add(new CinemaHall(_mainData.WorkDay, _mainData.Movies));

            MovieListBox.ItemsSource = _mainData.Movies;
            TimeTableList.ItemsSource = _mainData.MoviesByTime;
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
            _mainData.WorkDay = CreateWorkDay();
            _mainData.CinemaHalls[0].WorkDay = _mainData.WorkDay;
            _mainData.CinemaHalls[0].CreateTimeTable();
            _mainData.MoviesByTime = new ObservableCollection<MovieСard>();
            TimeTableList.ItemsSource = _mainData.MoviesByTime;

            foreach (var movieByTime in _mainData.CinemaHalls[0].TimeTable.MoviesByTime)
            {
                MovieСard movieСard = new MovieСard(movieByTime.Key, movieByTime.Value);
                string time = (movieByTime.Key + movieByTime.Value.Duration).ToString(@"hh\:mm");
                movieСard.movieTime.Text += " - " + time;
                _mainData.MoviesByTime.Add(movieСard);
            }
        }

        private WorkDay CreateWorkDay()
        {
            return new WorkDay(new TimeSpan(Convert.ToInt32(WorkTimeFrom.Text), 0, 0),
                new TimeSpan(Convert.ToInt32(WorkTimeTo.Text), 0, 0));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
