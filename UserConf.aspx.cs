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
        string userName;
        string realName;
        string dni;
        string tel;
        string email;
        string clave;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            fetchUserData();
            failText.Visible = false;
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
                                userName = reader.GetString(i);
                                if (!IsPostBack) nameInput.Value = userName;
                            }
                            if (reader.GetName(i).Equals("NombreCompleto"))
                            {
                                realName = reader.GetString(i);
                                if (!IsPostBack) realNameInput.Value = realName;
                            }
                            if (reader.GetName(i).Equals("DNI"))
                            {
                                dni = reader.GetString(i);
                                if (!IsPostBack) dniInput.Value = dni;
                            }
                            if (reader.GetName(i).Equals("Tel"))
                            {
                                tel = reader.GetInt32(i).ToString();
                                if (!IsPostBack) telInput.Value = tel;
                            }
                            if (reader.GetName(i).Equals("Email"))
                            {
                                email = reader.GetString(i);
                                if (!IsPostBack) emailInput.Value = email;
                            }
                            if (reader.GetName(i).Equals("Clave"))
                            {
                                clave = reader.GetString(i);
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
            var route = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connectionString = "data source=" + route;
            using(var db = new SQLiteConnection(connectionString))
            {
                db.Open();
                using(var cmd = new SQLiteCommand(query, db))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/User.aspx");
                    }
                    catch
                    {
                        failText.InnerText = "Error actualizando la información del usuario\nComando sql: " + query;
                        failText.Visible = true;
                    }
                }
            }
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
            var newName = nameInput.Value;
            var newRealName = realNameInput.Value;
            var newDni = dniInput.Value;
            var newTel = telInput.Value;
            var newEmail = emailInput.Value;
            var newPass = passwordInput.Value;

            if (newName == "") newName = userName;
            if (newRealName == "") newRealName = realName;
            if (newDni == "") newDni = dni;
            if (newTel == "") newTel = tel;
            if (newEmail == "") newEmail = email;
            if (newPass == "") newPass = clave;

            return "Cuenta = \"" + newName + "\", " +
                "NombreCompleto = \"" + newRealName + "\", " +
                "DNI = \"" + newDni + "\", " +
                "Tel = \"" + newTel + "\", " +
                "Email = \"" + newEmail + "\", " +
                "Clave = \"" + newPass + "\" WHERE ID = " + Session["id"];
        }

        protected void cancel(object sender, EventArgs e)
        {
            Response.Redirect("~/User.aspx");
        }
    }
}