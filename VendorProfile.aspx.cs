using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Web;
using System.Web.UI;

namespace Sharefy_MDA
{
    public partial class VendorProfile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["profile_id"];
            System.Diagnostics.Debug.WriteLine("Debug: info for vendor = " + id);
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
        
    }
}