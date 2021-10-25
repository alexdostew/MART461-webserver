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
            string userName = txtUsername.Text;
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string email = txtEmail.Text;

            Users myUser = new Users();
            myUser.insertNewUser(userName, fName, lName, email);

            showTable();
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