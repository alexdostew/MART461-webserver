using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Portfolio
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Write("Not Post Back");
            }
            else
            {
                //string username = txtUsername.Text;
                //byte[] salt = Utilities.CreateSalt();
                //byte[] pwd = Utilities.CreateHash(txtPwd.Text, salt);
                //Response.Write("salt: " + salt.Length);
                //Response.Write("<br/>");
                //Response.Write("pwd: " + pwd.Length);

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            byte[] salt = Utilities.CreateSalt();
            byte[] pwd = Utilities.CreateHash(txtPwd.Text, salt);
            string email = txtEmail.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            string myQuery = "spInsertNewUser";

            

            SqlConnection myConnection;

            myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            myCommand.Parameters.Add("@pwd", SqlDbType.VarBinary).Value = pwd;
            myCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            myCommand.Parameters.Add("@firstname", SqlDbType.VarChar).Value = firstName;
            myCommand.Parameters.Add("@lastname", SqlDbType.VarChar).Value = lastName;
            myCommand.Parameters.Add("@salt", SqlDbType.VarBinary).Value = salt;

            myCommand.ExecuteNonQuery();
            myConnection.Close();
            Response.Redirect(Request.RawUrl);
        }
    }
}