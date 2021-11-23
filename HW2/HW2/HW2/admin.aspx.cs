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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillUsers();
            } else
            {
                int userID = Convert.ToInt32(ddlUsers.SelectedValue);

                if(userID > 0 && Session["userid"] == null)
                {
                    Session["userid"] = userID;
                    fillSpecificUser(userID);
                }
            }
        }

        private void fillUsers()
        {
            Users myUser = new Users();
            DataSet myDataSet = myUser.getAllUsers();

            ddlUsers.DataSource = myDataSet.Tables[0];
            ddlUsers.DataTextField = "fulluser";
            ddlUsers.DataValueField = "userId";
            ddlUsers.DataBind();
            ddlUsers.Items.Insert(0, new ListItem("-- choose --", "-1"));
            gvUsers.DataSource = myDataSet.Tables[0];
            gvUsers.DataBind();
        }

        private void fillSpecificUser(int userId)
        {
            Users myUser = new Users();
            DataSet myDataSet = myUser.getSpecificUser(userId);

            txtUsername.Text = myDataSet.Tables[0].Rows[0]["username"].ToString();
            txtFirstName.Text = myDataSet.Tables[0].Rows[0]["firstname"].ToString();
            txtLastName.Text = myDataSet.Tables[0].Rows[0]["lastname"].ToString();
            txtEmail.Text = myDataSet.Tables[0].Rows[0]["email"].ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string email = txtEmail.Text;
            int userID = Convert.ToInt32(Session["userid"]);

            Users myUser = new Users();
            myUser.updateUser(userID, userName, fName, lName, email);

            resetFields();
            fillUsers();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["userid"]);

            Users myUser = new Users();
            myUser.deleteUser(userID);

            
            fillUsers();
            resetFields();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string email = txtEmail.Text;
            byte[] salt = Utilities.CreateSalt();
            byte[] pwd = Utilities.CreateHash(txtPwd.Text, salt);
            string saltstring = Convert.ToBase64String(salt);

            Users myUser = new Users();
            myUser.insertNewUser(userName, pwd, fName, lName, email, saltstring);

            resetFields();
            fillUsers();
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