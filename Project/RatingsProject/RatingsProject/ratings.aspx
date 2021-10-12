<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ratings.aspx.cs" Inherits="RatingsProject.ratings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="currentRatings">
        </div>
        <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblRating" runat="server" Text="Rating: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblComment" runat="server" Text="Comment: "></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="202px" Width="459px"></asp:TextBox>
        <br />
        <asp:Button ID="btnUploadIMG" runat="server" Text="Upload Image" />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
    </form>
</body>
</html>
