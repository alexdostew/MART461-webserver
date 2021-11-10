using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace Portfolio
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
            {
                if (txtPwd.Text != "" && txtUsername.Text != "")
                {
                    Users user = new Users();
                    string username = txtUsername.Text;
                    DataSet userData = user.getSpecificUser(username);
                    if (userData.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("User Exists!");
                        string pass = txtPwd.Text;
                        string usersalt = userData.Tables[0].Rows[0]["salt"].ToString();
                        byte[] userpwd = Utilities.CreateHash(pass, Convert.FromBase64String(usersalt));
                        userData = user.getSpecificUserWithPwd(username, userpwd);
                        if (userData.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("Passwords Match!");
                        } else
                        {
                            Response.Write("Passwords Do Not Match!");
                        }
                    } else
                    {
                        Response.Write("User Does Not Exist!");
                    }
                } else
                {
                    Response.Write("Please enter a username/password");
                }

            }
        }
    }
}