using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Write("Not Post Back");
            }
            else
            {
                string userName = txtUsername.Text;
                string pwd = txtPwd.Text;
                //Utilities.CreateHash(pwd);
            }
        }
    }
}