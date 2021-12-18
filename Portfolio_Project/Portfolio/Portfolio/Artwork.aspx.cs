using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Artwork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = new Users();
            if (Request.QueryString["imgid"] == null)
            {
                Response.Redirect("login.aspx");
            } 

            Images image = new Images();
            int imgID = Convert.ToInt32(Request.QueryString["imgID"]);
            DataSet userImages = image.getImagesWithID(imgID);
            DataSet users = user.getSpecificUserWithID(Convert.ToInt32(userImages.Tables[0].Rows[0]["userid"]));
            string imgTitle = userImages.Tables[0].Rows[0]["imgname"].ToString();
            string imgDesc = userImages.Tables[0].Rows[0]["imgdesc"].ToString();
            selectedImg.InnerHtml += "<img style='max-width: 100%;' src='./images/" + users.Tables[0].Rows[0]["username"] + "/" + userImages.Tables[0].Rows[0]["imgpath"] + "' />";
            imageTitle.InnerHtml = imgTitle;
            imageDesc.InnerHtml = imgDesc;

            Comments comment = new Comments();
            DataSet commentData = comment.getComments(imgID);

            for (int i = 0; i < commentData.Tables[0].Rows.Count; i++)
            {
                string commentName = "notset";
                if (commentData.Tables[0].Rows[i]["userid"] == DBNull.Value)
                {
                    commentName = "Guest";
                } else
                {
                    DataSet newUserData = user.getSpecificUserWithID((int)commentData.Tables[0].Rows[i]["userid"]);
                    commentName = newUserData.Tables[0].Rows[0]["username"].ToString();  
                }
                imageComments.InnerHtml += "<div style='background-color: grey; margin: 5px;'><label>" + commentName + "</label><p>" + commentData.Tables[0].Rows[i]["comment"] + "</p></div>";
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

            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Comments comment = new Comments();
            if (Session["username"] != null)
            {
                Users newUser = new Users();
                DataSet userData = newUser.getSpecificUser(Session["username"].ToString());
                int userID = (int)userData.Tables[0].Rows[0]["userid"];
                string newComment = commentBox.Text;
                comment.InsertComment(userID, Convert.ToInt32(Request.QueryString["imgID"]), newComment, DateTime.Now);
            } else
            {
                string newComment = commentBox.Text;
                comment.InsertCommentNoID(Convert.ToInt32(Request.QueryString["imgID"]), newComment, DateTime.Now);
            }
            
        }
    }
}