using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            failText.Visible = false;
        }

        protected void create(object sender, EventArgs e)
        {
            if (checkRequirements())
            {
                createUser(buildQuery());
            }
        }

        protected bool checkRequirements()
        {
            var userName = userNameInput.Value;
            var pass = passwordInput.Value;

            if(userName.Equals("") || pass.Equals(""))
            {
                failText.InnerText = "No se han facilitado los campos obligatorios";
                failText.Visible = true;
                return false;
            }

            return true;
        }

        protected string buildQuery()
        {
            return getBase() + buildValues();
        }

        protected string getBase()
        {
            return "insert into Usuarios (Cuenta, Clave, NombreCompleto, DNI, Tel, Email, Rol) values (";
        }

        protected string buildValues()
        {
            var userName = userNameInput.Value;
            var pass = passwordInput.Value;
            var name = realNameInput.Value;
            var dni = dniInput.Value;
            var tel = phoneNumberInput.Value;
            var mail = mailInput.Value;
            return
                "\"" +
                userName + "\",\"" +
                pass + "\",\"" +
                name + "\",\"" +
                dni + "\",\"" +
                tel + "\",\"" +
                mail + "\",\"" +
                "usuario" + "\")";
        }

        protected void createUser(string sqlSentence)
        {
            var dbRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var conString = "data source=" + dbRoute;

            using(var db = new SQLiteConnection(conString))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(sqlSentence, db))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        failText.InnerText = "Error añadiendo a la base de datos";
                        failText.Visible = true;
                    }
                }
            }
        }
    }
}