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
        public ObservableCollection<Movie> Movies { get; set; }
        public TimeSpan TimeLeft;

        public Movie Movie;
        public TimeSpan Time;

        public List<Node> AllPreviousMovies;
        public List<Node> NextNodes;

        public Node(TimeSpan timeLeft, TimeSpan time, ObservableCollection<Movie> movies, List<Node> allPreviousMovies = null)
        {
            TimeLeft = timeLeft;
            Time = time;
            Movies = movies;
            NextNodes = new List<Node>();

            if (allPreviousMovies is null)
            {
                AllPreviousMovies = new List<Node>();
            }
            else
            {
                AllPreviousMovies = allPreviousMovies;
            }
        }

        public void CreateGraph()
        {
            foreach (Movie movie in Movies)
            {
                if (movie.Duration <= TimeLeft)
                {
                    List<Node> newAllPreviousMovies = new List<Node>(AllPreviousMovies);
                    Movie = movie;
                    Node previousNode = (Node)this.Clone();
                    newAllPreviousMovies.Add(previousNode);

                    ObservableCollection<Movie> newMoviesList = new ObservableCollection<Movie>(Movies);
                    //newMoviesList.Remove(movie);

                    Node nextNode = new Node(TimeLeft - movie.Duration, Time + movie.Duration, newMoviesList, newAllPreviousMovies);
                    NextNodes.Add(nextNode);
                    nextNode.CreateGraph();
                }
            }
        }

        public void WriteAllLeaves()
        {
            if (NextNodes.Count == 0)
            {
                foreach (Node currentMovie in AllPreviousMovies)
                {
                    if (currentMovie.Movie != null)
                    {
                        Console.WriteLine(currentMovie + " ");
                    }
                }

                Console.WriteLine();
            }
            else
            {
                foreach (Node n in NextNodes)
                {
                    n.WriteAllLeaves();
                }
            }
        }

        public Node SelectOptinalBranch()
        {
            if(NextNodes.Count == 0)
            {
                return (Node)this.Clone();
            }
            else
            {
                List<Node> branches = new List<Node>();

                foreach (Node node in NextNodes)
                {
                    branches.Add(node.SelectOptinalBranch());
                }

                Node min = branches[0];

                foreach (Node r in branches)
                {
                    if (min.TimeLeft > r.TimeLeft)
                    {
                        min = r;
                    }
                    else if ((min.TimeLeft == r.TimeLeft) && (min.AllPreviousMovies.Count > r.AllPreviousMovies.Count))
                    {
                        min = r;
                    }
                }

                return min;
            }
        }

        public object Clone()
        {
            Node cloneNode = new Node(TimeLeft, Time, new ObservableCollection<Movie>(Movies), new List<Node>(AllPreviousMovies));

            if (Movie != null)
            {
                cloneNode.Movie = (Movie)Movie.Clone();
            }

            return cloneNode;
        }
        
        public override string ToString()
        {
            return $"{Movie.Name}({Movie.Duration}) at {Time}";
        }
    }
}
