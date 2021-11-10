using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Portfolio
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (txtUsername.Text != "" && txtPwd.Text != "" && txtEmail.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "")
                {
                    Users user = new Users();
                    string username = txtUsername.Text;
                    if (user.checkUsername(username))
                    {
                        Response.Write("username not available");
                    } else
                    {
                        byte[] salt = Utilities.CreateSalt();
                        byte[] pwd = Utilities.CreateHash(txtPwd.Text, salt);
                        string saltstring = Convert.ToBase64String(salt);
                        string email = txtEmail.Text;
                        string firstname = txtFirstName.Text;
                        string lastname = txtLastName.Text;


                        user.insertNewUser(username, pwd, email, firstname, lastname, saltstring);

                        Response.Redirect("login.aspx");
                    }
                } else
                {
                    Response.Write("Please fill out all fields");
                }
            }
        }
    }
}