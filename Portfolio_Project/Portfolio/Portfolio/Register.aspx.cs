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
                    string username = txtUsername.Text;
                    byte[] salt = Utilities.CreateSalt();
                    for (int i = 0; i < salt.Length; i++)
                    {
                        Response.Write(salt[i]);

                    }
                    Response.Write("<br/>");
                    string stringsalt = Convert.ToBase64String(salt);

                    salt = Encoding.UTF8.GetBytes(stringsalt);

                    for (int i = 0; i < salt.Length; i++)
                    {
                        Response.Write(salt[i]);

                    }
                    Response.Write("<br/>");

                    byte[] pwd = Utilities.CreateHash(txtPwd.Text, salt);

                    for (int i = 0; i < pwd.Length; i++)
                    {
                        Response.Write(pwd[i]);
                    }


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
                    myCommand.Parameters.Add("@salt", SqlDbType.VarChar).Value = stringsalt;

                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    Response.Redirect("login.aspx");
                } else
                {
                    Response.Write("Please fill out all fields");
                }
            }
        }
    }
}