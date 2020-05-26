using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;

namespace Sharefy_MDA
{
    public partial class VendorProfile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["profile_id"];
            System.Diagnostics.Debug.WriteLine("Debug: info for vendor = " + id);
            if(id == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            Session["profileId"] = id;
            setProfileValue("profileName", "select NombreCompleto from Usuarios WHERE ID=\"" + id + "\"");
            setProfileValue("profileTel", "select Tel from Usuarios WHERE ID=\"" + id + "\"");
            setProfileValue("profileEmail", "select Email from Usuarios WHERE ID=\"" + id + "\"");
        }

        protected void setProfileValue(string key, string sql)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(sql, db))
                {
                    var reader = cmd.ExecuteReader();
                    var str = "";
                    while (reader.Read()) str = reader[0].ToString();
                    Session[key] = str;
                }

                db.Close();
            }
        }

        protected void showDialog(object sender, EventArgs e)
        {
            messageTitleLabel.Visible = true;
            messageTitleInput.Visible = true;
            messageBodyLabel.Visible = true;
            messageBodyInput.Visible = true;
            messageSubmitButton.Visible = true;
        }

        protected void sendMessage(object sender, EventArgs e)
        {
            messageTitleLabel.Visible = false;
            messageTitleInput.Visible = false;
            messageBodyLabel.Visible = false;
            messageBodyInput.Visible = false;
            messageSubmitButton.Visible = false;

            System.Diagnostics.Debug.WriteLine(buildQuery());

            var route = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + route;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                var cmd = new SQLiteCommand(buildQuery(), db);
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        protected string buildQuery()
        {
            var str =
                "INSERT INTO Mensajes_Usuario (IDEmisor, IDReceptor, Titulo, Cuerpo, Fecha_envio, Estado) " +
                "values ("
                + "\"" + Session["id"] + "\", "
                + "\"" + Session["profileId"] + "\", "
                + "\"" + messageTitleInput.Value + "\", "
                + "\"" + messageBodyInput.Value + "\", "
                + "\"" + DateTime.Today.ToString("yyyy-MM-dd") + "\", "
                + "\"Enviado\"" + ")";
            return str;
        }

    }
}