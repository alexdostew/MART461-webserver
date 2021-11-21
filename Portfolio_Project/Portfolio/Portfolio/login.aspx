<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Portfolio.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="styles/main.css" />
    <link href="https://fonts.googleapis.com/css2?family=Rubik:ital,wght@0,300;0,500;0,600;0,800;1,800&display=swap" rel="stylesheet" />
</head>
<body>
    <div id="navbar" class="navbar" runat="server">
        <div id="userItem" class="nav-item" runat="server"><div id="userDiv" runat="server"></div></div>
        <div id="loginBtn" class="nav-item" runat="server"><a href="login.aspx">Log In</a></div>
        <div id="signupBtn" class="nav-item" runat="server"><a href="register.aspx">Sign Up</a></div>
        <div id="logoutBtn" class="nav-item" runat="server"><a href="logout.aspx">Log Out</a></div>
    </div>
    
    <div class="page-container">
        <div class="item-container small">
            <h2>Login</h2>
            <form id="form1" runat="server">
                <div class="form-container">
                    <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtUsername" runat="server"></asp:TextBox>
                    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtPwd" runat="server"></asp:TextBox>
                </div>


                <asp:Button CssClass="btn-submit" ID="btnSubmit" runat="server" Text="Submit" />
            </form>
        </div>
        <p>Don't have an account? <a href="register.aspx">Sign Up</a></p>
    </div>
    
</body>
</html>
