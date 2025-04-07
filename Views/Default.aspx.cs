using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using MovieReviewPortal.Models;

namespace MovieReviewPortal
{
    public partial class Default : System.Web.UI.Page
    {
        // Константы для учетных данных администратора
        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin123";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMovies();        // Загрузить список фильмов
                ConfigureInterface(); // Настроить интерфейс
                LoadMovieDropDown();  // Загрузить фильмы в выпадающий список для отзывов
                LoadReviews(); // Загрузить отзывы
            }
        }

        // Настройка интерфейса в зависимости от роли пользователя
        private void ConfigureInterface()
        {
            if (User.Identity.IsAuthenticated)
            {
                LoginButton.Visible = false;
                LogoutButton.Visible = true;
                RegisterButton.Visible = false;

                // Проверка на роль администратора
                if (User.Identity.Name == AdminUsername)
                {
                    AddMoviePanel.Visible = true; // Панель для добавления фильмов
                    foreach (GridViewRow row in MoviesGridView.Rows)
                    {
                        var deleteButton = (Button)row.FindControl("DeleteButton");
                        if (deleteButton != null) deleteButton.Visible = true;
                    }
                }
                else
                {
                    AddMoviePanel.Visible = false;
                }

                ReviewPanel.Visible = User.Identity.IsAuthenticated; // Панель для добавления отзывов
            }
            else
            {
                LoginButton.Visible = true;
                RegisterButton.Visible = true;
                LogoutButton.Visible = false;
                AddMoviePanel.Visible = false;
                ReviewPanel.Visible = false;
            }
        }

        // Загрузка списка фильмов в GridView
        private void LoadMovies()
        {
            using (var context = new MovieDBEntities())
            {
                var movies = context.movies.ToList();
                MoviesGridView.DataSource = movies;
                MoviesGridView.DataBind();
            }
        }

        // Загрузка фильмов в выпадающий список для добавления отзывов
        private void LoadMovieDropDown()
        {
            using (var context = new MovieDBEntities())
            {
                var movies = context.movies.Select(m => new { m.Id, m.title }).ToList();
                MovieDropDown.DataSource = movies;
                MovieDropDown.DataTextField = "Title";
                MovieDropDown.DataValueField = "Id";
                MovieDropDown.DataBind();
            }
        }

        // Добавление нового фильма (доступно только администратору)
        protected void AddMovieButton_Click(object sender, EventArgs e)
        {
            if (User.Identity.Name != AdminUsername)
            {
                ErrorMessageLabel.Text = "У вас нет прав на добавление фильмов.";
                ErrorMessageLabel.Visible = true;
                return;
            }

            try
            {
                string title = TitleTextBox.Text.Trim();
                string genre = GenreTextBox.Text.Trim();
                int year = int.Parse(YearTextBox.Text.Trim());
                decimal rating = decimal.Parse(RatingTextBox.Text.Trim());
                string description = DescriptionTextBox.Text.Trim();

                using (var context = new MovieDBEntities())
                {
                    var newMovie = new movies
                    {
                        title = title,
                        genre = genre,
                        year = year,
                        rating = (double?)rating,
                        description = description
                    };

                    context.movies.Add(newMovie);
                    context.SaveChanges();
                }

                // Очистка полей и скрытие сообщения об ошибке
                TitleTextBox.Text = "";
                GenreTextBox.Text = "";
                YearTextBox.Text = "";
                RatingTextBox.Text = "";
                DescriptionTextBox.Text = "";

                ErrorMessageLabel.Visible = false;

                LoadMovies();
                ConfigureInterface();
                LoadMovieDropDown();

                SuccessMessageLabel.Text = "Фильм успешно добавлен.";
                SuccessMessageLabel.Visible = true;
            }
            catch (FormatException)
            {
                ErrorMessageLabel.Text = "Проверьте правильность введенных данных.";
                ErrorMessageLabel.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorMessageLabel.Text = $"Ошибка: {ex.Message}";
                ErrorMessageLabel.Visible = true;
            }
        }

        // Обработка действий в GridView (удаление фильма)
        protected void MoviesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteMovie")
            {
                if (User.Identity.Name != AdminUsername)
                {
                    return;
                }

                int movieId = Convert.ToInt32(e.CommandArgument);
                using (var context = new MovieDBEntities())
                {
                    var movie = context.movies.FirstOrDefault(m => m.Id == movieId);
                    if (movie != null)
                    {
                        context.movies.Remove(movie);
                        context.SaveChanges();
                        LoadMovies();
                        ConfigureInterface();
                        LoadMovieDropDown();
                    }
                }
            }
        }

        // Добавление нового отзыва (доступно для всех авторизованных пользователей)
        protected void AddReviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                int movieId = int.Parse(MovieDropDown.SelectedValue);
                decimal rating = decimal.Parse(ReviewRatingTextBox.Text.Trim());
                string reviewText = ReviewTextBox.Text.Trim();

                using (var context = new MovieDBEntities())
                {
                    // Получение ID пользователя по имени
                    string username = User.Identity.Name;
                    var user = context.users.FirstOrDefault(u => u.login == username);

                    if (user == null)
                    {
                        ReviewErrorLabel.Text = "Пользователь не найден.";
                        ReviewErrorLabel.Visible = true;
                        return;
                    }

                    var newReview = new reviews
                    {
                        movie_id = movieId,
                        user_id = user.Id,
                        rating = (int)rating,
                        review = reviewText
                    };

                    context.reviews.Add(newReview);
                    context.SaveChanges();
                }

                ReviewTextBox.Text = "";
                ReviewRatingTextBox.Text = "";
                ReviewSuccessLabel.Text = "Отзыв успешно добавлен!";
                ReviewSuccessLabel.Visible = true;

                LoadReviews();
            }
            catch (FormatException)
            {
                ReviewErrorLabel.Text = "Проверьте правильность введенных данных.";
                ReviewErrorLabel.Visible = true;
            }
            catch (Exception ex)
            {
                ReviewErrorLabel.Text += $"Ошибка: {ex.Message}";
                Response.Write(ex.InnerException.InnerException.Message);
                ReviewErrorLabel.Visible = true;
            }
        }

        // Обработка вывода отзывов
        private void LoadReviews()
        {
            using (var context = new MovieDBEntities())
            {
                var reviews = context.reviews
                    .Select(r => new
                    {
                        MovieTitle = r.movies.title,
                        UserName = r.users.login,
                        Rating = r.rating,  
                        ReviewText = r.review   
                    })
                    .ToList();

                ReviewsRepeater.DataSource = reviews;
                ReviewsRepeater.DataBind();
            }
        }


        // Обработка кнопок входа и выхода
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
