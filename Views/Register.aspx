<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MovieReviewPortal.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Регистрация</title>
    <link href="../Content/register.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="RegisterForm" runat="server">
        <div>
            <h2>Регистрация</h2>

            <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" Visible="false" ></asp:Label>

            <asp:Label ID="UsernameLabel" runat="server" Text="Имя пользователя:" AssociatedControlID="UsernameTextBox" ></asp:Label>
            <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="input-field" ></asp:TextBox>
            <br />

            <asp:Label ID="PasswordLabel" runat="server" Text="Пароль:" AssociatedControlID="PasswordTextBox" ></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="input-field" ></asp:TextBox>
            <br />

            <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Повторите пароль:" AssociatedControlID="ConfirmPasswordTextBox" ></asp:Label>
            <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" CssClass="input-field" ></asp:TextBox>
            <br />

            <asp:Button ID="RegisterButton" runat="server" Text="Зарегистрироваться" OnClick="RegisterButton_Click" CssClass="custom-button" />
        </div>
    </form>
</body>
</html>
