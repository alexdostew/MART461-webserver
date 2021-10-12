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

            string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            string myQuery = "INSERT INTO Users (Username, FirstName, LastName, email) " +
                "VALUES ('" + userName + "', '" + fName + "', '" + lName + "', '" + email + "');";

            SqlConnection myConnection;

            myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            myCommand.ExecuteNonQuery();
            myConnection.Close();

            showTable();
        }

        private void showTable()
        {
            string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection myConnection;

            myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();

            string myQuery = "SELECT * FROM Users";

            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);
            myConnection.Close();

            gvUsers.DataSource = myDataSet.Tables[0];
            gvUsers.DataBind();
        }

        
    }
}