using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;

namespace Sharefy_MDA
{
    public partial class UserConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            fetchUserData();
        }

        protected void fetchUserData()
        {
            var route = HttpContext.Current.Server.MapPath(@"\BDCoches.db");
            var connnectionString = "data source=" + route;

            using (var db = new SQLiteConnection(connnectionString))
            {
                db.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Usuarios WHERE ID=" + Session["id"], db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            if (reader.GetName(i).Equals("Cuenta"))
                            {
                                nameInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("NombreCompleto"))
                            {
                                realNameInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("DNI"))
                            {
                                dniInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("Tel"))
                            {
                                telInput.Value = reader.GetInt32(i).ToString();
                            }
                            if (reader.GetName(i).Equals("Email"))
                            {
                                emailInput.Value = reader.GetString(i);
                            }
                        }
                    }
                }
            }
        }

        protected void saveChanges(object sender, EventArgs e)
        {
            modifyUser(buildQuery());
        }

        protected void modifyUser(string query)
        {

        }

        protected string buildQuery()
        {
            return buildBase() + buildValues();
        }

        protected string buildBase()
        {
            return "UPDATE Usuarios SET ";
        }

        protected string buildValues()
        {

        }
    }
}