using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MovieReviewPortal.Models;

namespace MovieReviewPortal
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            string confirmPassword = ConfirmPasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageLabel.Text = "Все поля должны быть заполнены.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                MessageLabel.Visible = true;
                return;
            }

            if (password != confirmPassword)
            {
                MessageLabel.Text = "Пароли не совпадают.";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                MessageLabel.Visible = true;
                return;
            }

            try
            {
                using (var context = new MovieDBEntities())
                {
                    // Проверка, существует ли пользователь с таким именем
                    var existingUser = context.users.FirstOrDefault(u => u.login == username);
                    if (existingUser != null)
                    {
                        MessageLabel.Text = "Пользователь с таким именем уже существует.";
                        MessageLabel.ForeColor = System.Drawing.Color.Red;
                        MessageLabel.Visible = true;
                        return;
                    }

                    // Создаем нового пользователя
                    var newUser = new users
                    {
                        login = username,
                        password = password
                    };

                    context.users.Add(newUser);

                    // Сохраняем данные
                    context.SaveChanges();
                }

                MessageLabel.Text = "Регистрация успешно завершена!";
                MessageLabel.ForeColor = System.Drawing.Color.Green;
                MessageLabel.Visible = true;

                // Очищаем поля
                UsernameTextBox.Text = "";
                PasswordTextBox.Text = "";
                ConfirmPasswordTextBox.Text = "";

                Response.Redirect("Default.aspx");
            }
            catch (DbEntityValidationException validationException)
            {
                // Вывод всех ошибок валидации
                foreach (var validationError in validationException.EntityValidationErrors)
                {
                    foreach (var error in validationError.ValidationErrors)
                    {
                        MessageLabel.Text += $"Property: {error.PropertyName} - Error: {error.ErrorMessage}<br />";
                    }
                }

                MessageLabel.ForeColor = System.Drawing.Color.Red;
                MessageLabel.Visible = true;
            }
            catch (Exception ex)
            {
                // Другие ошибки
                Response.Write("\n");
                Response.Write(ex.InnerException.InnerException.Message);
                MessageLabel.Text = $"Произошла ошибка: {ex.Message}";
                MessageLabel.ForeColor = System.Drawing.Color.Red;
                MessageLabel.Visible = true;
            }
        }
    }
}
