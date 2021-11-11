<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Portfolio.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="styles/main.css" />
</head>
<body>
    <div class="page-container">
        <div class="item-container">
            <h2>Register</h2>
            <form id="form1" runat="server">
                <div class="form-container">
                    <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtUsername" runat="server"></asp:TextBox>

                    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtPwd" runat="server"></asp:TextBox>

                    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtEmail" runat="server"></asp:TextBox>

                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtFirstName" runat="server"></asp:TextBox>

                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                    <asp:TextBox CssClass="text-input" ID="txtLastName" runat="server"></asp:TextBox>
                </div>

                <div class="btn-submit">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit"/>
                </div>
            </form>
        </div>
        <p>Already have an account? <a href="login.aspx">Log in</a></p>
    </div>
</body>
</html>
