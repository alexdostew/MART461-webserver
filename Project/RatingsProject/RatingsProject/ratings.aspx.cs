using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace RatingsProject
{
    public partial class ratings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowComments();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string comment = txtComment.Text;
            string imgPath = "";

            //image strings
            string fileName;
            string filePath;
            string dFolder;

            //image folder location
            dFolder = Server.MapPath("./images/");

            //get file name
            fileName = oFile.PostedFile.FileName;
            //fileName = Path.GetFileName(fileName);

            //check if fields are empty
            if (username != null && comment != null && ddlRating.SelectedIndex != 0)
            {
                int rating = Convert.ToInt32(ddlRating.SelectedValue);

                //image processing
                if(oFile.Value != "")
                {
                    // create images folder if it doesnt exist
                    if(!Directory.Exists(dFolder))
                    {
                        Directory.CreateDirectory(dFolder);
                    }

                    filePath = dFolder + fileName;
                    if(File.Exists(filePath))
                    {
                        //temp - add id# or username to images to prevent duplicate names
                        imgPath = fileName;
                    } else
                    {
                        oFile.PostedFile.SaveAs(filePath);
                        imgPath = fileName;
                    }
                } else
                {
                    imgPath = null;
                }
                
                string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

                string myQuery = "INSERT INTO ratings (username, rating, img, comment) " +
                    "VALUES ('" + username + "', '" + rating + "', '" + imgPath + "', '" + comment + "');";

                SqlConnection myConnection;

                myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand(myQuery);
                myCommand.Connection = myConnection;
                myCommand.CommandType = CommandType.Text;

                myCommand.ExecuteNonQuery();
                myConnection.Close();
                ClearText();
                Response.Redirect(Request.RawUrl);
            } else
            {
                Response.Write("please fill out the form");
            }

        }

        private void ShowComments()
        {
            string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection myConnection;

            myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();

            string myQuery = "SELECT * FROM ratings";

            DataSet myDataSet = new DataSet();
            SqlCommand myCommand = new SqlCommand(myQuery);
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            myAdapter.Fill(myDataSet);
            myConnection.Close();

            gvComments.DataSource = myDataSet.Tables[0];
            gvComments.DataBind();
            
            foreach (DataTable table in myDataSet.Tables)
            {
                List<Object> subjects = new List<Object>();
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        object item = row[column];
                        subjects.Add(item);
                        //Response.Write(item);
                    }
                    string newDiv = "<div style='background-color: cyan; margin: 5px; max-width: 500px;'><div>Username: " + subjects[1].ToString() + "</div>" +
                        "<div>Rating: " + subjects[2].ToString() + "</div>" +
                        "<div>Comment: " + subjects[3].ToString() + "</div>";

                    if (subjects[4].ToString() != "")
                    {
                        newDiv += "<div><img src=./images/" + subjects[4].ToString() + " style='max-width: 400px; padding: 5px;' /></div><br />";
                    }

                    newDiv += "</div>";

                    currentRatings.Controls.Add(new LiteralControl(newDiv));
                    //Response.Write(newDiv);
                    subjects.Clear();
                }
            }
        }

        private void ClearText()
        {
            txtComment.Text = "";
            txtUsername.Text = "";
            ddlRating.SelectedIndex = 0;
        }
    }
}