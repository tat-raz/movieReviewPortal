using System;
using System.Web;
using System.Web.Security;

namespace MovieReviewPortal
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Проверка, что пользователь уже аутентифицирован
            if (User.Identity.IsAuthenticated)
            {
                // Выход из системы
                Session.Abandon();
                FormsAuthentication.SignOut();
            }

            // Перенаправление на главную страницу после выхода
            Response.Redirect("Default.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Логика выхода
            Session.Abandon();
            FormsAuthentication.SignOut();

            // Перенаправление на главную страницу
            Response.Redirect("Default.aspx");
        }
    }
}   
