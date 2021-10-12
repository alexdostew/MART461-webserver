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
                Session["userId"] = userID;

                if (!Convert.ToBoolean(Session["dontfillusers"]))
                {
                    fillSpecificUser(userID);
                }
                
            }
            
            
        }

        private void fillUsers()
        {
            string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection myConnection;

            myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();

            string myQuery = "SELECT userId, username + ': ' + firstname + ' ' + lastname as fulluser, email FROM Users";

            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);
            myConnection.Close();

            ddlUsers.DataSource = myDataSet.Tables[0];
            ddlUsers.DataTextField = "fulluser";
            ddlUsers.DataValueField = "userId";
            ddlUsers.DataBind();
            gvUsers.DataSource = myDataSet.Tables[0];
            gvUsers.DataBind();
        }

        private void fillSpecificUser(int userId)
        {
            string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection myConnection;

            myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();

            string myQuery = "SELECT username, firstname, lastname, email FROM Users WHERE userId = " + userId;

            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);
            myConnection.Close();

            txtUsername.Text = myDataSet.Tables[0].Rows[0]["username"].ToString();
            txtFirstName.Text = myDataSet.Tables[0].Rows[0]["firstname"].ToString();
            txtLastName.Text = myDataSet.Tables[0].Rows[0]["lastname"].ToString();
            txtEmail.Text = myDataSet.Tables[0].Rows[0]["email"].ToString();

            Session["dontfillusers"] = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string email = txtEmail.Text;
            int userID = Convert.ToInt32(Session["userID"]);

            string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            string myQuery = "UPDATE Users SET username ='" + userName + "', firstname= '" + fName + "', lastname='" + lName + "', email='" + email + "' WHERE userId = " + userID;

            SqlConnection myConnection;

            myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            myCommand.ExecuteNonQuery();
            myConnection.Close();

            Session["dontfillusers"] = false;
        }
    }
}