<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Artwork.aspx.cs" Inherits="Portfolio.Artwork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="styles/main.css" />
    <link href="https://fonts.googleapis.com/css2?family=Rubik:ital,wght@0,300;0,500;0,600;0,800;1,800&display=swap" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>
<body>
    <div id="navbar" class="navbar" runat="server">
        <div id="userItem" class="nav-item" runat="server"><div id="userDiv" runat="server"></div></div>
        <div id="loginBtn" class="nav-item" runat="server"><a href="login.aspx">Log In</a></div>
        <div id="signupBtn" class="nav-item" runat="server"><a href="register.aspx">Sign Up</a></div>
        <div id="logoutBtn" class="nav-item" runat="server"><a href="logout.aspx">Log Out</a></div>
    </div>
    <div id="pageContainer" runat="server" class="page-container">
        <div id="imagesContainer" class="images-container" runat="server"></div>
            <form id="galleryForm" runat="server" method="post" enctype="multipart/form-data">
                <div id="imageDescription" class="item-container overlay" runat="server">

                    <div class="form-container">
                        <div id="selectedImg" runat="server"></div>
                        <h2 id="imageTitle" runat="server"></h2>
                        <label>Description:</label>
                        <p id="imageDesc" runat="server"></p>
                        <label>Comments:</label>
                        <div id="imageComments" runat="server"></div>
                        <label>New Comment:</label>
                        <asp:TextBox ID="commentBox" runat="server" Height="202px" Width="459px" TextMode="MultiLine"></asp:TextBox>

                        <asp:Button CssClass="btn-submit" ID="Button2" runat="server" Text="Submit Comment" OnClick="btnSubmit_Click" ValidationGroup="userimages" />
                    </div>
                </div>
            </form>
    </div>
</body>
</html>
