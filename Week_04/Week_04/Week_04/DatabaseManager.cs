using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Week_04.Models;
using Xamarin.Forms;

namespace Week_04
{
    public class DatabaseManager
    {
        readonly SQLiteConnection Connection = DependencyService.Get<IDBInterface>().CreateConnection();
        public DatabaseManager()
        {
        }

        public User GetUser()
        {
            return Connection.FindWithQuery<User>("SELECT * FROM User WHERE LoggedIn = 1");
        }

        public List<Movie> GetAllMovies()
        {
            return Connection.Query<Movie>("SELECT * FROM Movie");
        }

        public List<Series> GetAllSeries()
        {
            return Connection.Query<Series>("SELECT * FROM Serie");
        }

        public List<Movie> GetAllMoviesByUser(string username)
        {
            return Connection.Query<Movie>("SELECT Movie.* FROM Movie, MovieUser, User WHERE Username = ? AND MovieUser.UserID = User.UserID AND Movie.MovieID = MovieUser.MovieID", username);
        }

        public List<Series> GetAllSeriesByUser(string username)
        {
            return Connection.Query<Series>("SELECT Serie.* FROM Serie, SerieUser, User WHERE Username = ? AND SerieUser.UserID = User.UserID AND Serie.SerieID = SerieUser.SerieID", username);
        }

        public void AddMovie(string title, string description, int year)
        {
            Connection.Insert(new Movie { Title = title, Description = description, Year = year });
        }

        public void AddSeries(string title, string description, int yearStarted, int yearEnded, int numberOfEpisodes, int numberOfSeasons)
        {
            Connection.Insert(new Series { Title = title, Description = description, YearStarted = yearStarted, YearEnded = yearEnded, numberOfEpisodes = numberOfEpisodes, NumberOfSeasons = numberOfSeasons });
        }

        public void AddUser(string username, string password)
        {
            Connection.Insert(new User { Username = username, Password = password });
        }

        public bool DoesUserExist(string username, string password)
        {
            return Connection.Query<User>("SELECT * FROM User WHERE Username = ? AND Password = ?", username, password).Count > 0;
        }

        public void UserLogin(string username)
        {
            Connection.Execute("UPDATE User SET LoggedIn = 1 WHERE Username = ?", username);
        }

        public void UserLogout()
        {
            Connection.Execute("UPDATE User SET LoggedIn = 0");
        }
    }
}
