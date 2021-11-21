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
            Users user = new Users();
            if (Page.IsPostBack)
            {
                if (txtPwd.Text != "" && txtUsername.Text != "")
                {
                    string username = txtUsername.Text;
                    DataSet userData = user.getSpecificUser(username);
                    if (userData.Tables[0].Rows.Count > 0)
                    {
                        string pass = txtPwd.Text;
                        string usersalt = userData.Tables[0].Rows[0]["salt"].ToString();
                        byte[] userpwd = Utilities.CreateHash(pass, Convert.FromBase64String(usersalt));
                        userData = user.getSpecificUserWithPwd(username, userpwd);
                        if (userData.Tables[0].Rows.Count > 0)
                        {
                            Session["username"] = userData.Tables[0].Rows[0]["username"].ToString();
                            
                        } else
                        {
                            Response.Write("Username or password is invalid");
                        }
                    } else
                    {
                        Response.Write("Username or password is invalid");
                    }
                } else
                {
                    Response.Write("Please enter a username/password");
                }
            }
            if (Session["username"] != null)
            {
                userItem.Visible = true;
                logoutBtn.Visible = true;
                loginBtn.Visible = false;
                signupBtn.Visible = false;
                userItem.InnerHtml = "<a href=gallery.aspx?user=" + Session["username"].ToString() + ">" + Session["username"].ToString() + "</a>";
            } else
            {
                userItem.Visible = false;
                logoutBtn.Visible = false;
                loginBtn.Visible = true;
                signupBtn.Visible = true;
            }
            
        }
    }
}