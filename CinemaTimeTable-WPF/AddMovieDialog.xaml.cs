using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CinemaTimeTable_WPF
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class AddMovieDialog : Window
    {
        public AddMovieDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MainData mainData = MainData.GetMainData();
            //TimeSpan duration = new TimeSpan(0, Convert.ToInt32(MovieDurationTextBox.Text), 0);
            //Movie movie = new Movie(MovieNameTextBox.Text, duration);
            //movie.Description = MovieDescriptionTextBox.Text;
            //mainData.Movies.Add(movie);

            this.Close();
        }

        private void MovieDurationTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
