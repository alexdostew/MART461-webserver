<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ratings.aspx.cs" Inherits="RatingsProject.ratings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="currentRatings" runat="server">
            <br />
            <asp:GridView ID="gvComments" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
        </div>
        <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblRating" runat="server" Text="Rating: "></asp:Label>
        <asp:DropDownList ID="ddlRating" runat="server">
            <asp:ListItem>-- Select a rating --</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblComment" runat="server" Text="Comment: "></asp:Label>
        <br />
        <asp:TextBox ID="txtComment" runat="server" Height="202px" Width="459px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblFile" runat="server" Text="Select an image file to upload to the server:"></asp:Label>
        <br />
        <input id="oFile" type="file" runat="server" name="oFile"/><br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit comment" OnClick="btnSubmit_Click" />
    </form>
</body>
</html>
