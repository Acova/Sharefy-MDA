using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["id"] == null))
            {
                if (Session["rol"].Equals("usuario"))
                {
                    adminLink.Visible = false;
                }
                loginLink.Visible = false;
                registerLink.Visible = false;
            }
            else
            {
                logoutLink.Visible = false;
                accountLink.Visible = false;
                adminLink.Visible = false;
                messagesLink.Visible = false;
            }
            
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session["id"] = null;
            Session["userName"] = null;
            Session["rol"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}