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
            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:LinkButton ID="btnPasswordReset" runat="server" OnClick="btnPasswordReset_Click">Reset Password</asp:LinkButton>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Log In" />
            <br />
            <br />
            <asp:Button ID="btnSignup" runat="server" OnClick="btnSignup_Click" Text="Sign Up" />
        </div>
    </form>
</body>
</html>
