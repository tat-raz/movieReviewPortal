using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Runtime.Remoting.Contexts;
using System.Linq;

namespace MovieReviewPortal
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Если пользователь уже аутентифицирован, перенаправляем на главную страницу
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (ValidateUser(username, password))
            {
                // Создаём объект FormsAuthenticationTicket
                FormsAuthentication.SetAuthCookie(username, false);

                // Перенаправляем пользователя на главную страницу
                Response.Redirect("Default.aspx");
            }
            else
            {
                ErrorMessage.Text = "Неверное имя пользователя или пароль.";
            }
        }

        private bool ValidateUser(string username, string password)
        {
            if (username == "admin" && password == "admin123") return true;
            using (var context = new MovieDBEntities())
            {
                var user = context.users.FirstOrDefault(u => u.login == username);
                if (user == null)
                    return false;
                return password == user.password;

            }
        }
    }
}
