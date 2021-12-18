using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace Portfolio
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect if query string doesnt match existing user
            Users user = new Users();
            Images image = new Images();
            if (Request.QueryString["user"] == null || !user.checkUsername(Request.QueryString["user"]))
            {
                Response.Redirect("login.aspx");
            }

            // navigation buttons
            if (Session["username"] != null)
            {
                userItem.Visible = true;
                logoutBtn.Visible = true;
                loginBtn.Visible = false;
                signupBtn.Visible = false;
                userItem.InnerHtml = "<a href=gallery.aspx?user=" + Session["username"].ToString() + ">" + Session["username"].ToString() + "</a>";
            }
            else
            {
                userItem.Visible = false;
                logoutBtn.Visible = false;
                loginBtn.Visible = true;
                signupBtn.Visible = true;
            }

            // show/hide upload buttons/panels
            if (Session["username"] != null && Request.QueryString["user"] == Session["username"].ToString())
            {
                openPanel.Visible = true;
                uploadContainer.Visible = true;
            } else
            {
                openPanel.Visible = false;
                uploadContainer.Visible = false;
            }

            //Show images for specific userid
            DataSet userData = user.getSpecificUser(Request.QueryString["user"]);
            int userID = (int)userData.Tables[0].Rows[0]["userid"];
            DataSet userImages = image.getImages(userID);
            for (int i = 0; i < userImages.Tables[0].Rows.Count; i++)
            {
                string bgImage = "background-image: url('./images/'" + userImages.Tables[0].Rows[i]["imgpath"] + "')";
                imagesContainer.InnerHtml += "<div id=" + userImages.Tables[0].Rows[i]["imgid"] + " style=\"background-image: url('./images/" + Request.QueryString["user"] + "/" + userImages.Tables[0].Rows[i]["imgpath"] + "')\" class='img-block'></div>";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && Request.QueryString["user"] == Session["username"].ToString())
            {
                //image strings
                string fileName;
                string filePath;
                string dFolder;

                string title = txtTitle.Text;
                string desc = txtDesc.Text;
                DateTime date = DateTime.Now;

                //image folder location
                dFolder = Server.MapPath("./images/" + Session["username"].ToString() + "/");

                //get file name
                fileName = date.ToString("yyyymmddMMss") + ImageUpload.PostedFile.FileName;
                //fileName = Path.GetFileName(fileName);

                //image processing
                if (ImageUpload.HasFile)
                {
                    // create images folder if it doesnt exist
                    if (!Directory.Exists(dFolder))
                    {
                        Directory.CreateDirectory(dFolder);
                    }

                    filePath = dFolder + fileName;
                    if (File.Exists(filePath))
                    {
                        Response.Write("file already exists");
                    }
                    else
                    {
                        ImageUpload.PostedFile.SaveAs(filePath);
                        Users user = new Users();
                        Images image = new Images();
                        DataSet userData = user.getSpecificUser(Session["username"].ToString());
                        int userID = (int)userData.Tables[0].Rows[0]["userid"];
                        image.InsertImage(userID, title, desc, date, fileName);
                        Response.Redirect("Gallery.aspx?user=" + Request.QueryString["user"]);
                    }
                }
            }
        }
    }
}