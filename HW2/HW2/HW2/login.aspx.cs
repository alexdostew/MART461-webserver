using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HW2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = new Users();
            if (Page.IsPostBack)
            {
                if (txtPwd.Text != "" && txtUsername.Text != "")
                {
                    string username = txtUsername.Text;
                    DataSet userData = user.getSpecificUsername(username);
                    if (userData.Tables[0].Rows.Count > 0)
                    {
                        string pass = txtPwd.Text;
                        string usersalt = userData.Tables[0].Rows[0]["salt"].ToString();
                        byte[] userpwd = Utilities.CreateHash(pass, Convert.FromBase64String(usersalt));
                        userData = user.getSpecificUserWithPwd(username, userpwd);
                        if (userData.Tables[0].Rows.Count > 0)
                        {
                            Session["username"] = userData.Tables[0].Rows[0]["username"].ToString();
                            Response.Write("Username + password match!");
                        }
                        else
                        {
                            Response.Write("Username or password is invalid");
                        }
                    }
                    else
                    {
                        Response.Write("Username or password is invalid");
                    }
                }
                else
                {
                    Response.Write("Please enter a username/password");
                }
            }
        }
    }
}