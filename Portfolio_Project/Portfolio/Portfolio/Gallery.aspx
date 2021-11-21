<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="Portfolio.Gallery" %>

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
        <div id="loginBtn" class="nav-item" runat="server"><a href="./login.aspx">Log In</a></div>
        <div id="signupBtn" class="nav-item" runat="server"><a href="register.aspx">Sign Up</a></div>
        <div id="logoutBtn" class="nav-item" runat="server"><a href="logout.aspx">Log Out</a></div>
    </div>

    <button id="openPanel" runat="server">Upload image</button>
    
    <div id="pageContainer" runat="server" class="page-container">
        <div id="imagesContainer" class="images-container" runat="server"></div>
            <form id="uploadForm" runat="server" method="post" enctype="multipart/form-data">

                <div id="uploadContainer" class="item-container overlay" runat="server">

                    <button type="button" id="closeBtn" class="btn-close" runat="server">X</button>

                    <div class="form-container">
                        <h2>Upload Image</h2>

                        <asp:FileUpload ID="ImageUpload" runat="server" accept="image/jpeg, image/png"/>
                        <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                            ControlToValidate="ImageUpload"
                            ErrorMessage="Only JPEG or PNG images are allowed" 
                            ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([Pp][Nn][Gg])$)" ValidationGroup="userimages">
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequireImageFile" runat="server" 
                            ControlToValidate="ImageUpload" ErrorMessage="File Required!" ValidationGroup="userimages">
                        </asp:RequiredFieldValidator>
                        
                        <asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequireTitle" runat="server" 
                            ControlToValidate="txtTitle" ErrorMessage="Title Required!" ValidationGroup="userimages">
                        </asp:RequiredFieldValidator>

                        <asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label>
                        <asp:TextBox ID="txtDesc" runat="server" Height="202px" Width="459px" TextMode="MultiLine"></asp:TextBox>

                        <asp:Button CssClass="btn-submit" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="userimages" />
                    </div>
                </div>
            </form>
        <script type="text/javascript">
            $('#uploadContainer').hide();
            $('#openPanel').click(function () {
                $('#uploadContainer').fadeIn("fast");
            });
            $('#closeBtn').click(function () {
                $('#uploadContainer').fadeOut("fast");
            });
        </script>
    </div>
    
</body>
</html>
