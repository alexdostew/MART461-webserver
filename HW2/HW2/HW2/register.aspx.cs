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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Write("Here");
                showTable();
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPwd.Text != "" && txtEmail.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "")
            {
                Users user = new Users();
                string username = txtUsername.Text;
                if (user.checkUsername(username))
                {
                    Response.Write("username not available");
                }
                else
                {
                    byte[] salt = Utilities.CreateSalt();
                    byte[] pwd = Utilities.CreateHash(txtPwd.Text, salt);
                    string saltstring = Convert.ToBase64String(salt);
                    string email = txtEmail.Text;
                    string firstname = txtFirstName.Text;
                    string lastname = txtLastName.Text;

                    user.insertNewUser(username, pwd, email, firstname, lastname, saltstring);

                    Response.Redirect("login.aspx");
                    showTable();
                }
            }
            else
            {
                Response.Write("Please fill out all fields");
            }
        }

        private void showTable()
        {
            Users myUser = new Users();
            DataSet myDataSet = myUser.getAllUsers();
            gvUsers.DataSource = myDataSet.Tables[0];
            gvUsers.DataBind();
            resetFields();
        }

        private void resetFields()
        {
            txtUsername.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            Session["userid"] = null;
        }

    }
}