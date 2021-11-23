<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HW2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPwd" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Log In" />
            <br />
            <br />
            <p>Don't have an account? <a href="register.aspx">Sign Up</a></p>
        </div>
    </form>
</body>
</html>
