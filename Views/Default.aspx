<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieReviewPortal.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Главная страница</title>
    <link href="../Content/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="buttonsForm" runat="server">
        <div class="auth-buttons">
            <asp:Button ID="LoginButton" runat="server" Text="Войти" OnClick="LoginButton_Click" CssClass="custom-button" />
            <asp:Button ID="LogoutButton" runat="server" Text="Выйти" OnClick="LogoutButton_Click" CssClass="custom-button" />
            <asp:Button ID="RegisterButton" runat="server" Text="Зарегистрироваться" OnClick="RegisterButton_Click" CssClass="custom-button" />
        </div>

        <!-- Панель добавления нового фильма -->
        <asp:Panel ID="AddMoviePanel" runat="server" CssClass="form-panel" Visible="false">
            <h3>Добавить новый фильм</h3>
            <asp:Label ID="TitleLabel" runat="server" Text="Название:"></asp:Label>
            <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="GenreLabel" runat="server" Text="Жанр:"></asp:Label>
            <asp:TextBox ID="GenreTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="YearLabel" runat="server" Text="Год:"></asp:Label>
            <asp:TextBox ID="YearTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="RatingLabel" runat="server" Text="Рейтинг:"></asp:Label>
            <asp:TextBox ID="RatingTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="DescriptionLabel" runat="server" Text="Описание:"></asp:Label>
            <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine" Rows="4" Columns="40"></asp:TextBox>
            <br />
            <asp:Button ID="AddMovieButton" runat="server" Text="Добавить фильм" OnClick="AddMovieButton_Click" />
            <asp:Label ID="SuccessMessageLabel" runat="server" ForeColor="Green" Visible="false"></asp:Label>
            <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </asp:Panel>
        <hr />

        <!-- Таблица фильмов -->
        <asp:GridView ID="MoviesGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            OnRowCommand="MoviesGridView_RowCommand" CssClass="movies-table">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Название" />
                <asp:BoundField DataField="Genre" HeaderText="Жанр" />
                <asp:BoundField DataField="Year" HeaderText="Год" />
                <asp:BoundField DataField="Rating" HeaderText="Рейтинг" />
                <asp:BoundField DataField="Description" HeaderText="Описание" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="DeleteButton" CssClass="delete-button" runat="server" Text="Удалить" CommandName="DeleteMovie" CommandArgument='<%# Eval("Id") %>' Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <!-- Секция для отображения отзывов -->
        <asp:Panel ID="ReviewsPanel" runat="server" CssClass="reviews-section">
            <h2>Отзывы</h2>
            <asp:Repeater ID="ReviewsRepeater" runat="server">
                <ItemTemplate>
                    <div class="review-card">
                        <h3><%# Eval("MovieTitle") %></h3>
                        <p><strong>Пользователь:</strong> <%# Eval("UserName") %></p>
                        <p><strong>Рейтинг:</strong> <%# Eval("Rating") %> / 10</p>
                        <p><%# Eval("ReviewText") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>


        <!-- Секция для добавления отзывов -->
        <asp:Panel ID="ReviewPanel" runat="server" Visible="false">
            <h2>Добавить отзыв для фильма</h2>
            <asp:DropDownList ID="MovieDropDown" runat="server"></asp:DropDownList><br />
            <asp:TextBox ID="ReviewRatingTextBox" runat="server" Placeholder="Рейтинг (0-10)"></asp:TextBox><br />
            <asp:TextBox ID="ReviewTextBox" runat="server" TextMode="MultiLine" Placeholder="Введите отзыв"></asp:TextBox><br />
            <asp:Button ID="AddReviewButton" runat="server" Text="Добавить отзыв" OnClick="AddReviewButton_Click" />
            <asp:Label ID="ReviewSuccessLabel" runat="server" ForeColor="Green" Visible="false"></asp:Label>
            <asp:Label ID="ReviewErrorLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </asp:Panel>
    </form>
</body>
</html>
