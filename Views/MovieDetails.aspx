<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="MovieReviewPortal.MovieDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Movie Details</title>
</head>
<body>
    <form id="movieDetailsForm" runat="server">
        <div>
            <h2 id="MovieTitleLabel" runat="server"></h2>
            <p id="MovieDescriptionLabel" runat="server"></p>
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
