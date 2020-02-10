using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ServiceApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((string)Session["LoggedIn"] != "true")
            {
                Response.Redirect("Login.aspx");
            }
            UserLabel.DataBind();
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session["LoggedIn"] = "false";
            Session["User"] = "";
            Response.Redirect("Login.aspx");
        }
    }
}