using System;
using System.Linq;
using MovieReviewPortal.Models;

namespace MovieReviewPortal
{
    public partial class MovieDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMovieDetails();
            }
        }

        private void LoadMovieDetails()
        {
            int movieId;
            if (int.TryParse(Request.QueryString["id"], out movieId))
            {
                using (var context = new MoviesDbContext())
                {
                    var movie = context.Movies.FirstOrDefault(m => m.Id == movieId);
                    if (movie != null)
                    {
                        MovieTitleLabel.InnerText = movie.Title;
                        MovieDescriptionLabel.InnerText = movie.Description;
                    }
                    else
                    {
                        ErrorLabel.Text = "Фильм не найден.";
                    }
                }
            }
            else
            {
                ErrorLabel.Text = "Некорректный идентификатор фильма.";
            }
        }
    }
}
