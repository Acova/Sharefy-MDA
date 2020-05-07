using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            fetchUserData();
        }

        protected void fetchUserData()
        {
            var route = HttpContext.Current.Server.MapPath(@"\BDCoches.db");
            var connnectionString = "data source=" + route;

            using(var db = new SQLiteConnection(connnectionString))
            {
                db.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Usuarios WHERE ID=" + Session["id"], db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            if (reader.GetName(i).Equals("Cuenta"))
                            {
                                nameInput.Attributes.Add("readonly", "readonly");
                                nameInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("NombreCompleto"))
                            {
                                realNameInput.Attributes.Add("readonly", "readonly");
                                realNameInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("DNI"))
                            {
                                dniInput.Attributes.Add("readonly", "readonly");
                                dniInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("Tel"))
                            {
                                telInput.Attributes.Add("readonly", "readonly");
                                telInput.Value = reader.GetInt32(i).ToString();
                            }
                            if (reader.GetName(i).Equals("Email"))
                            {
                                emailInput.Attributes.Add("readonly", "readonly");
                                emailInput.Value = reader.GetString(i);
                            }
                        }
                    }
                }
            }
        }

        protected void editUser(object sender, EventArgs e)
        {
            
        }
    }
}