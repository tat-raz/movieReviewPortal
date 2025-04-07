<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="MovieReviewPortal.Logout" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logout</title>
</head>
<body>
    <form id="logoutForm" runat="server">
        <div>
            <h2>Выход</h2>
            <asp:Button ID="LogoutButton" runat="server" Text="Выйти" OnClick="LogoutButton_Click" />
        </div>
    </form>
</body>
</html>
