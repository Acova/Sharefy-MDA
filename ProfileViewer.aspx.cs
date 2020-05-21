using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;

namespace Sharefy_MDA
{
    public partial class ProfileViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if (id == null || id.Equals("")) Response.Redirect("~/Default.aspx");
            if (!Page.IsPostBack)
                fillData("SELECT * FROM Usuarios WHERE ID=" + id);
        }

        protected void fillData(string sql)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(sql, db))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        for (var i = 0; i < reader.FieldCount; i++)
                            if (!reader.IsDBNull(i))
                                switch (reader.GetName(i))
                                {
                                    case "NombreCompleto":
                                        nameInput.Value = reader.GetString(i);
                                        Session["profileName"] = nameInput.Value;
                                        break;
                                    case "DNI":
                                        dniInput.Value = reader.GetString(i);
                                        Session["profileDNI"] = dniInput.Value;
                                        break;
                                    case "Tel":
                                        phoneInput.Value = reader.GetInt32(i) + "";
                                        Session["profileTel"] = phoneInput.Value;
                                        break;
                                    case "Email":
                                        mailInput.Value = reader.GetString(i);
                                        Session["profileEmail"] = mailInput.Value;
                                        break;
                                    case "Clave":
                                        passwordInput.Value = reader.GetString(i);
                                        Session["profilePassword"] = passwordInput.Value;
                                        break;
                                }
                }

                db.Close();
            }
        }


        protected void cancel(object sender, EventArgs e)
        {
            Response.Redirect("~/ListUsers.aspx");
        }
    }
}