<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MovieReviewPortal.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Content/register.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="loginForm" runat="server">
        <div>
            <h2>Вход в систему</h2>

            <asp:Label ID="UserNameLabel" runat="server" Text="Имя пользователя:" AssociatedControlID="UserNameTextBox" />
            <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="input-field"  />
            <br />

            <asp:Label ID="PasswordLabel" runat="server" Text="Пароль:" AssociatedControlID="PasswordTextBox" />
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="input-field" />
            <br />

            <asp:Button ID="LoginButton" runat="server" Text="Войти" OnClick="LoginButton_Click" CssClass="custom-button" />
            
            <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
