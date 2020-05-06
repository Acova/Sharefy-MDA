using System;
using System.Data.SQLite;
using System.Web;
using System.Web.UI;

namespace Sharefy_MDA
{
    public partial class ProfileMod : Page
    {
        string userId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            success.Visible = false;
            fail.Visible = false;
            
            var id = Request.QueryString["id"];

            if(id == null || id.Equals("")) Response.Redirect("~/Default.aspx");

            userId = id;

            if (!Page.IsPostBack)
                fillData("SELECT * FROM Usuarios WHERE ID=" + id);
        }

        protected void modify(object sender, EventArgs e)
        {
            modifyUser(getQuery());
            Response.Redirect("~/ListUsers.aspx");
        }

        protected string getQuery()
        {
            return getBase() + getValues();
        }

        protected string getBase()
        {
            return "UPDATE Usuarios SET Clave = ";
        }

        protected string getValues()
        {
            var password = passwordInput.Value;
            var name = nameInput.Value;
            var dni = dniInput.Value;
            var tel = phoneInput.Value;
            var mail = mailInput.Value;
            var id = userId;


            if (password == "") password = Session["profilePassword"].ToString();
            if (name == "") name = Session["profileName"].ToString();
            if (dni == "") dni = Session["profileDNI"].ToString();
            if (tel == "") tel = Session["profileTel"].ToString();
            if (mail == "") mail = Session["profileEmail"].ToString();

            var URLvalue = "\'" + password + "\', NombreCompleto = \'" + name + "\', DNI = \'" + dni + "\', Tel = \'" + tel +
                   "\', Email = \'" + mail + "\' WHERE ID = " + id;

            return URLvalue;
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

        protected void modifyUser(string sql)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(sql, db))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        success.InnerText = "Modificación confirmado";
                        success.Visible = true;
                    }
                    catch
                    {
                        fail.InnerText = sql;
                        fail.Visible = true;
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