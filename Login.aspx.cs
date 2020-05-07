using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            failText.Visible = false;
            successText.Visible = false;
        }

        protected void login(object sender, EventArgs e)
        {
            if (checkRequirements())
            {
                loginUser(buildSQL());
            }
        }

        protected bool checkRequirements()
        {
            var userName = userNameInput.Value;
            var pass = passwordInput.Value;

            if(userName.Equals("") || pass.Equals(""))
            {
                failText.InnerText = "Debe introducir un usuario y contraseña válidos";
                failText.Visible = true;
                return false;
            }

            return true;
        }

        protected string buildSQL()
        {
            return buildBase() + buildArgs();
        }

        protected string buildBase()
        {
            return "select ID, NombreCompleto, Rol from Usuarios ";
        }

        protected string buildArgs()
        {
            var user = userNameInput.Value;
            var pass = passwordInput.Value;
            return "WHERE " +
                "Cuenta=\"" + user + "\"" +
                "and Clave=\"" + pass + "\"";
        }

        protected void loginUser(string sqlCommand)
        {
            var id = 0;
            var rol = "";
            var userName = "";
            var route = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var conString = "data source=" + route;
            using (var db = new SQLiteConnection(conString))
            {
                db.Open();
                using(var cmd = new SQLiteCommand(sqlCommand, db))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for(var i = 0; i < reader.FieldCount; i++)
                        {
                            if (!reader.IsDBNull(i))
                            {
                                if (reader.GetName(i).Equals("ID"))
                                {
                                    id = reader.GetInt32(i);
                                }
                                if (reader.GetName(i).Equals("Rol"))
                                {
                                    rol = reader.GetString(i);
                                }
                                if (reader.GetName(i).Equals("NombreCompleto"))
                                {
                                    userName = reader.GetString(i);
                                }
                            }
                        }
                    }
                    if (id == 0)
                    {
                        failText.InnerText = "Error en el inicio de sesión";
                        failText.Visible = true;
                    }
                    else
                    {
                        Session["id"] = id;
                        Session["rol"] = rol;
                        Session["userName"] = userName;
                        Response.Redirect("~/Default.aspx");
                    }
                }
                db.Close();
            }
        }
    }
}