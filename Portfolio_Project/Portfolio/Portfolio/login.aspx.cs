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
                    string username = txtUsername.Text;
                    string pass = txtPwd.Text;
                    byte[] salt = Convert.FromBase64String("4804nGDafdCprL0kdN32pjiLuugxZrP3");
                    byte[] usersalt;
                    byte[] pwd = Utilities.CreateHash(pass, salt);
                    byte[] userpwd = null;

                    string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    string myQuery = "SELECT * FROM users WHERE username='" + username + "'";


                    SqlConnection myConnection;

                    myConnection = new SqlConnection(myConnectionString);
                    myConnection.Open();

                    SqlDataReader reader;
                    SqlCommand myCommand = new SqlCommand(myQuery);
                    myCommand.Connection = myConnection;
                    myCommand.CommandType = CommandType.Text;

                    reader = myCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usersalt = Convert.FromBase64String(reader.GetString(6));
                            userpwd = Utilities.CreateHash(pass, usersalt);
                        }
                    }
                    else
                    {
                        Response.Write("Please enter a valid username/password");
                    }

                    reader.Close();

                    if (userpwd != null && userpwd.Length > 0)
                    {
                        string pwdQuery = "spSelectUser";
                        SqlDataReader pwdReader;
                        SqlCommand pwdCommand = new SqlCommand(pwdQuery);
                        pwdCommand.Connection = myConnection;
                        pwdCommand.CommandType = CommandType.StoredProcedure;
                        pwdCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                        pwdCommand.Parameters.Add("@pwd", SqlDbType.VarBinary).Value = userpwd;

                        pwdReader = pwdCommand.ExecuteReader();
                        if (pwdReader.HasRows)
                        {
                            Response.Write("Login Success!");
                        }
                        else
                        {
                            Response.Write("Please enter a valid username/password");
                        }
                        pwdReader.Close();
                    }
                    myConnection.Close();
                } else
                {
                    Response.Write("Please enter a username/password");
                }

            }
        }
    }
}