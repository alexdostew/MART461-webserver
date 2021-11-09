<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Portfolio.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="styles/main.css" />
</head>
<body>
    <div class="navbar">

    </div>
    
    <div class="page-container">
        <div class="item-container">
            <h2>Login</h2>
            <form id="form1" runat="server">
                <div class="form-container">
                    <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtUsername" runat="server"></asp:TextBox>
                    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtPwd" runat="server"></asp:TextBox>
                </div>

                <div class="btn-submit">

                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />

                </div>
            </form>
        </div>
    </div>
    
</body>
</html>
